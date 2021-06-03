using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soons.Models
{
    public class Order
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("orderNumber")]
        public String OrderNumber { get; set; }
        [JsonProperty("State")]
        public int State { get; set; }
    }
}
