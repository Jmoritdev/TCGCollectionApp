using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCGCollectionApp.Models {
    public class MTGRelatedUris {
        [Key]
        public int Id { get; set; }

        [JsonProperty("gatherer")]
        public Uri Gatherer { get; set; }

        [JsonProperty("tcgplayer_decks")]
        public Uri TcgplayerDecks { get; set; }

        [JsonProperty("edhrec")]
        public Uri Edhrec { get; set; }

        [JsonProperty("mtgtop8")]
        public Uri Mtgtop8 { get; set; }
    }
}
