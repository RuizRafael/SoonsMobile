using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Soons.Models
{
   
    public class Prod
    {
        [JsonProperty("id")]
        public int Id{ get; set; }
        [JsonProperty("sku")]
        public String SKU { get; set; }
        [JsonProperty("name")]
        public String Name{ get; set; }
        [JsonProperty("price")]
        public double Price{ get; set; }
        [JsonProperty("discount")]
        public int Discount { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("brand")]
        public String Brand { get; set; }
        [JsonProperty("sex")]
        public String Sex{ get; set; }
        [JsonProperty("category_Id")]
        public int Category_Id { get; set; }
        [JsonProperty("brand_Id")]
        public int Brand_Id { get; set; }
        [JsonProperty("color1")]
        public String Color1 { get; set; }
        [JsonProperty("color2")]
        public String Color2{ get; set; }
        [JsonProperty("imagen1")]
        public String Imagen1 { get; set; }
        [JsonProperty("imagen2")]
        public String Imagen2 { get; set; }
        [JsonProperty("imagen3")]
        public String Imagen3 { get; set; }
        [JsonProperty("imagen4")]
        public String Imagen4 { get; set; }
        [JsonProperty("imagen5")]
        public String Imagen5 { get; set; }
        [JsonProperty("imagen6")]
        public String Imagen6 { get; set; }
        [JsonProperty("noiva")]
        public int Noiva { get; set; }
        [JsonProperty("state")]
        public int State{ get; set; }
        [JsonProperty("createdate")]
        public String Createdate { get; set; }

    }
}
