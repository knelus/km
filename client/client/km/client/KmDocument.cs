using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Web;
namespace km.client
{
    class KmDocument : KmDataobject
    {
        public readonly int id;
        public string user;
        public string title;
        public string file;
        public string description;
        public string tags;
        public string fileData;
        private KmRelatedList related=null;

  

        public KmDocument(KmConnection con) : base(con) { }
        public KmDocument(KmConnection con, int id):base(con)
        {
            this.id = id;
            this.load();
        }
        public KmDocument(KmConnection con, Dictionary<string, string> data)
            : base(con)
        {
            this.id = int.Parse(data["id"]);
            load(data);
        }

        public void load(Dictionary<string, string> data)
        {
              

               this.file = data["file"];
               this.user = data["user"];
               this.title = data["title"];
               this.description = data["description"];
               this.tags = data["tags"];
        }


        public override void load()
        {
            try
            {
                Dictionary<string, string> data = con.loadDictionary("loadDocumentinfo", "{\"id\":\"" + this.id + "\"}");
                this.file = data["file"];
                this.user = data["user"];
                this.title = data["title"];
                this.tags = data["tags"];
                this.description = data["description"];
            }
            catch (Exception e)
            {
                
            }

        }

        public override string ToString()
        {
            return this.title;
        }

        public KmRelatedList getRelated()
        {
            if (this.related != null)
            {
                return related;
            }
            else
            {
                related = new KmRelatedList(this.con, this.tags,this.id);
                return related;
            }
        }

        public void interested(){
            con.loadDictionary("saveInterest","{\"tags\":\""+this.tags+"\"}");
        }

        public void loadFile(string file){
              FileStream reader = new FileStream(file, FileMode.Open);
              byte[] buffer =new byte[reader.Length];
              reader.Read(buffer, 0, (int)reader.Length);
              string encoded= Convert.ToBase64String(buffer);
              fileData = HttpUtility.UrlEncode(encoded);
                
        }

        public void save(string file)
        {
            loadFile(file);
            save();
        }

        public Dictionary<string,string> save()
        {
            string json= JsonConvert.SerializeObject(this);
            return con.loadDictionary("saveDocument", json);
        }

        public void download(string destination)
        {
            con.download(this.id,destination) ;
        }

        public void delete()
        {
            con.loadDictionary("deleteDocument", "{\"id\":\"" + this.id + "\"}");
        }
    }
}
