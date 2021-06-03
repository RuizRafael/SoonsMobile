using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soons.Models
{
 
    public class Category
    {
        [JsonProperty("category")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
