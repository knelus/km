using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace km.client
{
    class KmUser:KmDataobject
    {
        public readonly int id;
        public string username;
        public string password;
        public string fullName;
        public string email;
        public string lastLoginDate;
        public string registrationDate;
        public string profileText;
        public bool administrator;

        public int commonInterest=-1;

 

        public KmUser(KmConnection con):base(con){}
        public KmUser(KmConnection con, int id) : base(con) {
            this.id = id;
            load();
        }
        public KmUser(KmConnection con, Dictionary<string, string> data):base(con){
            this.id=int.Parse(data["id"]);
            this.load(data);
        }

        public void load(Dictionary<string, string> data)
        {
            this.username = data["username"];
            this.fullName = data["fullName"];
            this.email = data["email"];
            this.lastLoginDate = data["lastLoginDate"];
            this.registrationDate = data["registrationDate"];
            this.profileText = data["profileText"];

            if (data["administrator"] == "1")
            {
                this.administrator = true;
            }
            else
            {
                this.administrator = false;
            }

        }

        public override void load()
        {

            Dictionary<string, string> data = con.loadDictionary("loadProfile", "{\"id\":\"" + this.id + "\"}");
            this.username = data["username"];
            this.fullName = data["fullName"];
            this.email = data["email"];
            this.lastLoginDate = data["registrationDate"];
            this.profileText = data["profileText"];

            if (data["administrator"] == "1")
            {
                this.administrator = true;
            }
            else
            {
                this.administrator = false;
            }
        }

        public int getCommonInterest()
        {
            if (this.commonInterest<0)
            {
                Dictionary<string, string> data = con.loadDictionary("loadCommonInterest", "{\"id\":\"" + this.id + "\"}");
                this.commonInterest = int.Parse(data["commonInterest"]);
            }

            return this.commonInterest;
        }

        public override string ToString()
        {
            return this.username;
        }

        public Dictionary<string,string> save()
        {
            string json = JsonConvert.SerializeObject(this);
            return con.loadDictionary("saveUser", json);
        }


        public void delete()
        {
            con.loadDictionary("deleteUser", "{\"id\":\"" + this.id + "\"}");
        }
    }
}
