using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soons.Models
{

    public class Shop
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("street")]
        public String Street { get; set; }
        [JsonProperty("country")]
        public String Country { get; set; }
        [JsonProperty("phone")]
        public String Phone{ get; set; }
        [JsonProperty("email")]
        public String Email{ get; set; }
        [JsonProperty("latitude")]
        public String Latitude{ get; set; }
        [JsonProperty("longitude")]
        public String Longitude{ get; set; }
    }
}
