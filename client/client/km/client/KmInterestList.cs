using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace km.client
{
    class KmInterestList : KmDataobject
    {
        public List<KmDocument> list;
        public KmInterestList(KmConnection con) : base(con) {
            list=new List<KmDocument>();
            load();
        }
        public override void load()
        {
            Dictionary<string, Dictionary<string, string>> data = con.loadDoubleDictionary("loadInterestList");
            foreach (KeyValuePair<string, Dictionary<string, string>> document in data)
            {
                KmDocument documentObject = new KmDocument(con, document.Value);
                this.list.Add(documentObject);
            }
        }
    }
}
