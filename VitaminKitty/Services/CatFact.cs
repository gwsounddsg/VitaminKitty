using Newtonsoft.Json;
using System.IO;
using System.Net;
using VitaminKitty.Models;

namespace VitaminKitty.Services
{
    public class CatFact : ICatFact
    {
        private readonly string _url = "https://cat-fact.herokuapp.com/facts/random?animal_type=cat&amount=1";

        public Fact GetFact()
        {
            // calls url and converts result to json string
            WebRequest request = WebRequest.Create(_url);
            WebResponse response = request.GetResponse();
            
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();

            Fact fact = JsonConvert.DeserializeObject<Fact>(content);
            return fact;
        }
    }
}
