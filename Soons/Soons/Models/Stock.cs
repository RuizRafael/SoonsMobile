using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soons.Models
{
   
    public class Stock
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("prod")]
        public int ProdId { get; set; }
        [JsonProperty("shop")]
        public int ShopId { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("units")]
        public int Units { get; set; }
    }
}
