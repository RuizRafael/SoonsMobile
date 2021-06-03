using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Soons.Models
{
 
    public class Brand
    {
       
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("image")]
        public String Image{ get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
    }
}
