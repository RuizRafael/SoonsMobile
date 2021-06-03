using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soons.Models
{
    public class ProdsOrder
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("idOrder")]
        public int IdOrder { get; set; }
        [JsonProperty("idProd")]
        public int IdProd { get; set; }
    }
}
