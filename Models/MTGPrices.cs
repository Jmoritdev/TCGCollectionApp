using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCGCollectionApp.Models {
    public class MTGPrices {
        [Key]
        public int Id { get; set; }

        [JsonProperty("usd")]
        public string Usd { get; set; }

        [JsonProperty("usd_foil")]
        public string UsdFoil { get; set; }

        [JsonProperty("eur")]
        public string Eur { get; set; }

        [JsonProperty("tix")]
        public string Tix { get; set; }
    }
}
