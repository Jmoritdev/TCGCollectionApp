using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCGCollectionApp.Models {
    public class MTGPurchaseUris {
        [Key]
        public int Id { get; set; }

        [JsonProperty("tcgplayer")]
        public Uri Tcgplayer { get; set; }

        [JsonProperty("cardmarket")]
        public Uri Cardmarket { get; set; }

        [JsonProperty("cardhoarder")]
        public Uri Cardhoarder { get; set; }
    }
}
