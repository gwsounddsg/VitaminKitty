using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VitaminKitty.Models;

namespace VitaminKitty.Web
{
    public class CatFact
    {
        private readonly string _url = "https://cat-fact.herokuapp.com/facts";

        public string GetFact()
        {
            // calls url and converts result to json string
            WebRequest request = WebRequest.Create(_url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();

            //// gets first fact in array
            //var facts = JsonConvert.DeserializeObject<dynamic>(content);
            //return facts.all[0].text;

            List<Fact> facts = JsonConvert.DeserializeObject<List<Fact>>(content);
            Console.WriteLine(facts[0]);

            return "";
        }
    }
}
