using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace km.client
{
    class KmDocumentList: KmDataobject
    {

        public List<KmDocument> list;
        public string jsonIn = "";

        public KmDocumentList(KmConnection con) : base(con) {
            list=new List<KmDocument>();
            load(); }
        public KmDocumentList(KmConnection con, int userid)
            : base(con)
        {
             list=new List<KmDocument>();
            jsonIn = "{\"user\":\"" + userid + "\"}";
            this.load();
        
        }
        public KmDocumentList(KmConnection con,string search) : base(con) {
             list=new List<KmDocument>();
            jsonIn = "{\"search\":\"" + search + "\"}";
            this.load();
        }
        public KmDocumentList(KmConnection con, string search, int userid)
            : base(con)
        {
             list=new List<KmDocument>();
            jsonIn = "{\"search\":\"" + search + "\",\"user\":\"" + userid + "\"}";
            this.load();
        }








        public override void load()
        {
            Dictionary<string, Dictionary<string,string>> data = con.loadDoubleDictionary("loadDocumentlist",this.jsonIn);
            foreach(KeyValuePair<string,Dictionary<string,string>> document in data){
                
                KmDocument documentObject = new KmDocument(con, document.Value);
                this.list.Add(documentObject);
            }

        }




    }
}
