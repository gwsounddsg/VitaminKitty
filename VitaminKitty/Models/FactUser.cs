using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitaminKitty.Models
{
    public class FactUser
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public FactUserName Name { get; set; }
    }
}
