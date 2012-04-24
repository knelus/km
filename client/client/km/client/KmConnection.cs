using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using km.externalCode;
using Newtonsoft.Json;





namespace km.client
{
    class KmConnection
    {
        string host;
        bool loggedin;
        string username;
        string userhash;

        public KmConnection(string host){
            this.host=host;
            
        }

        public string getHost()
        {
            return this.host;
        }


        public bool auth(string username,string password)
        {
            PostSubmitter submitter = new PostSubmitter(this.host);
            submitter.PostItems.Add("username", username);
            submitter.PostItems.Add("password", password);
            submitter.PostItems.Add("script", "login");
            submitter.Type = PostSubmitter.PostTypeEnum.Post;
           
            Dictionary<String, String> userdata = JsonConvert.DeserializeObject<Dictionary<String, String>>(submitter.Post());

            if (userdata["succes"] == "1")
            {
                this.userhash = userdata["hash"];
                this.username = username;
                this.loggedin = true;
              
                return true;
            }
            else
            {
                this.loggedin = false;
                return false;
            }
          

           
        }
        
        public String loadScript(String script, String json){
            PostSubmitter submitter = new PostSubmitter(this.host);
            submitter.PostItems.Add("Uhash", this.userhash);
            submitter.PostItems.Add("Uname", this.username);
            submitter.PostItems.Add("script",script);
            submitter.PostItems.Add("json",json);
            submitter.Type = PostSubmitter.PostTypeEnum.Post;
            return submitter.Post();
        }

        public Dictionary<string, string> loadDictionary(string script, string json)
        {
            string data = this.loadScript(script, json);
     
            return   JsonConvert.DeserializeObject<Dictionary<String, String>>(data);
        }

        public Dictionary<string, string> loadDictionary(string script)
        {
            string data = this.loadScript(script, "{}");

            return JsonConvert.DeserializeObject<Dictionary<String, String>>(data);
        }

        public Dictionary<String,Dictionary<string,string>> loadDoubleDictionary(string script, string json){
            string data = this.loadScript(script, json);
             return JsonConvert.DeserializeObject<Dictionary<string,Dictionary<string,string>>>(data);
        }

        public Dictionary<String, Dictionary<string, string>> loadDoubleDictionary(string script)
        {
            return this.loadDoubleDictionary(script, "");
        }


        public Dictionary<string, string> convertJson(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<String, String>>(json);
        }
           
        public void download(int id,string destination)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(this.host + "openFile.php?id="+id, destination);
        }
      



    }
}
