using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitaminKitty.Models
{
    public class Fact
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public FactUser User { get; set; }

        [JsonProperty("upvotes")]
        public int UpVotes { get; set; }
    }
}
