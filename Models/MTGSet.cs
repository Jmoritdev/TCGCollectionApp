using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCGCollectionApp.Models {
    public class MTGSet {

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        [Key]
        public string Code { get; set; }

        [JsonProperty("mtgo_code")]
        public string MtgoCode { get; set; }

        [JsonProperty("arena_code")]
        public string ArenaCode { get; set; }

        [JsonProperty("tcgplayer_id")]
        public int TcgplayerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("scryfall_uri")]
        public Uri ScryfallUri { get; set; }

        [JsonProperty("search_uri")]
        public Uri SearchUri { get; set; }

        [JsonProperty("released_at")]
        public DateTimeOffset ReleasedAt { get; set; }

        [JsonProperty("set_type")]
        public string SetType { get; set; }

        [JsonProperty("card_count")]
        public int CardCount { get; set; }

        [JsonProperty("digital")]
        public bool Digital { get; set; }

        [JsonProperty("foil_only")]
        public bool FoilOnly { get; set; }

        [JsonProperty("block_code")]
        public string BlockCode { get; set; }

        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("icon_svg_uri")]
        public Uri IconSvgUri { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string IconSvgBase64 { get; set; }

        [ForeignKey("Set")]
        public virtual ICollection<MTGCard> Cards { get; set; }
    }
}
