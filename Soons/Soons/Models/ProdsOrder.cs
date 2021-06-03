using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soons.Models
{
    public class ProdsOrder
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("idOrder")]
        public int idOrder { get; set; }
        [JsonProperty("idProd")]
        public int idProd { get; set; }
    }
}
