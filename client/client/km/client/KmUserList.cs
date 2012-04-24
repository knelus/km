using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace km.client
{
    class KmUserList:KmDataobject
    {
        private string jsonString;
        public List<KmUser> list;
        public KmUserList(KmConnection con) : base(con) 
        { 
           list= new List<KmUser>();
           load(); 
        }
        public KmUserList(KmConnection con, string search)
            : base(con)
        {
            list=new List<KmUser>();
            load(search);   
        }

        public void load(string search)
        {
            this.jsonString = "{\"search\":\""+search+"\"}";
            doLoad();
        }

        public override void load()
        {
            this.jsonString = "";
            doLoad();
        }

        private void doLoad()
        {
            Dictionary<string, Dictionary<string, string>> data = con.loadDoubleDictionary("loadUserList", jsonString);
            foreach (KeyValuePair<string, Dictionary<string, string>> user in data)
            {
                KmUser userObject = new KmUser(con, user.Value);
                this.list.Add(userObject);
            }

        }


    }
}
