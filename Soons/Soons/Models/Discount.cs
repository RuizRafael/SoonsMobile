using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Soons.Models
{

    public class Discount
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("code")]
        public String Code{ get; set; }
        [JsonProperty("offer")]
        public int Offer { get; set; }
    }
}
