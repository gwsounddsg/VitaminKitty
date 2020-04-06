using Newtonsoft.Json;

namespace VitaminKitty.Models
{
    public class FactUserName
    {
        [JsonProperty("first")]
        public string First { get; set; }
        
        [JsonProperty("last")]
        public string Last { get; set; }
    }
}
