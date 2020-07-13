using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TCGCollectionApp.Models {
    public class MTGCard {

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        [Key]
        public string Id { get; set; }

        [JsonProperty("oracle_id")]
        public string OracleId { get; set; }

        [NotMapped]
        [JsonProperty("multiverse_ids")]
        public List<int> MultiverseIds { get; set; } = new List<int>();

        public string MultiverseIdsJson {
            get {
                return MultiverseIds == null || MultiverseIds.Count == 0
                   ? null
                   :  System.Text.Json.JsonSerializer.Serialize(MultiverseIds);
            }
            set {
                if (string.IsNullOrEmpty(value))
                    MultiverseIds.Clear();
                else
                    MultiverseIds = JsonConvert.DeserializeObject<List<int>>(value);
            }
        }


        [JsonProperty("mtgo_id")]
        public int MtgoId { get; set; }

        [JsonProperty("arena_id")]
        public int ArenaId { get; set; }

        [JsonProperty("tcgplayer_id")]
        public int TcgplayerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("released_at")]
        public DateTimeOffset ReleasedAt { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("scryfall_uri")]
        public Uri ScryfallUri { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("highres_image")]
        public bool HighresImage { get; set; }

        [JsonProperty("image_uris")]
        public MTGImageUris ImageUris { get; set; }

        [JsonProperty("mana_cost")]
        public string ManaCost { get; set; }

        [JsonProperty("cmc")]
        public double Cmc { get; set; }

        [JsonProperty("type_line")]
        public string TypeLine { get; set; }

        [NotMapped]
        [JsonProperty("colors")]
        public List<string> Colors { get; set; } = new List<string>();

        public string ColorsJson {
            get {
                return Colors == null || Colors.Count == 0
                   ? null
                   : System.Text.Json.JsonSerializer.Serialize(Colors);
            }
            set {
                if (value == null)
                    Colors.Clear();
                else
                    Colors = System.Text.Json.JsonSerializer.Deserialize<List<string>>(value);
            }
        }


        [NotMapped]
        [JsonProperty("color_identity")]
        public List<string> ColorIdentity { get; set; } = new List<string>();

        public string ColorIdentityJson {
            get {
                return ColorIdentity == null || ColorIdentity.Count == 0
                   ? null
                   : JsonConvert.SerializeObject(ColorIdentity);
            }
            set {
                //Console.WriteLine(value);
                if (value == null)
                    ColorIdentity.Clear();
                else
                    ColorIdentity = System.Text.Json.JsonSerializer.Deserialize<List<string>>(value);
            }
        }


        [JsonProperty("card_faces")]
        public List<MTGCardFace> CardFaces { get; set; }

        [JsonProperty("legalities")]
        public MTGLegalities Legalities { get; set; }


        [NotMapped]
        [JsonProperty("games")]
        public List<string> Games { get; set; } = new List<string>();
        
        public string GamesJson {
            get {
                return Games == null || Games.Count == 0
                   ? null
                   : JsonConvert.SerializeObject(Games);
            }
            set {
                if (value == null)
                    Games.Clear();
                else
                    Games = System.Text.Json.JsonSerializer.Deserialize<List<string>>(value);
            }
        }


        [JsonProperty("reserved")]
        public bool Reserved { get; set; }

        [JsonProperty("foil")]
        public bool Foil { get; set; }

        [JsonProperty("nonfoil")]
        public bool Nonfoil { get; set; }

        [JsonProperty("oversized")]
        public bool Oversized { get; set; }

        [JsonProperty("promo")]
        public bool Promo { get; set; }

        [JsonProperty("reprint")]
        public bool Reprint { get; set; }

        [JsonProperty("variation")]
        public bool Variation { get; set; }

        [JsonProperty("set")]
        public string Set { get; set; }

        [JsonProperty("set_name")]
        public string SetName { get; set; }

        [JsonProperty("set_type")]
        public string SetType { get; set; }

        [JsonProperty("set_uri")]
        public Uri SetUri { get; set; }

        [JsonProperty("set_search_uri")]
        public Uri SetSearchUri { get; set; }

        [JsonProperty("scryfall_set_uri")]
        public Uri ScryfallSetUri { get; set; }

        [JsonProperty("rulings_uri")]
        public Uri RulingsUri { get; set; }

        [JsonProperty("prints_search_uri")]
        public Uri PrintsSearchUri { get; set; }

        [JsonProperty("collector_number")]
        public string CollectorNumber { get; set; }

        [JsonProperty("digital")]
        public bool Digital { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("card_back_id")]
        public string CardBackId { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }


        [NotMapped]
        [JsonProperty("artist_ids")]
        public List<string> ArtistIds { get; set; } = new List<string>();

        public string ArtistIdsJson {
            get {
                return ArtistIds == null || ArtistIds.Count == 0
                   ? null
                   : JsonConvert.SerializeObject(ArtistIds);
            }
            set {
                if (value == null)
                    ArtistIds.Clear();
                else
                    ArtistIds = JsonConvert.DeserializeObject<List<string>>(value);
            }
        }

        [JsonProperty("illustration_id")]
        public string IllustrationId { get; set; }

        [JsonProperty("border_color")]
        public string BorderColor { get; set; }

        [JsonProperty("frame")]
        public string Frame { get; set; }

        [JsonProperty("full_art")]
        public bool FullArt { get; set; }

        [JsonProperty("textless")]
        public bool Textless { get; set; }

        [JsonProperty("booster")]
        public bool Booster { get; set; }

        [JsonProperty("story_spotlight")]
        public bool StorySpotlight { get; set; }

        [JsonProperty("edhrec_rank")]
        public int EdhrecRank { get; set; }

        [JsonProperty("prices")]
        public MTGPrices Prices { get; set; }

        [JsonProperty("related_uris")]
        public MTGRelatedUris RelatedUris { get; set; }

        [JsonProperty("purchase_uris")]
        public MTGPurchaseUris PurchaseUris { get; set; }
    }
}
