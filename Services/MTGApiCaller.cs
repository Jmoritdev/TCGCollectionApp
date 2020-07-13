using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Services {
    public class MTGApiCaller : IApiCaller {

        const string API_URL = "https://api.scryfall.com";
        private readonly HttpClient httpClient;

        public MTGApiCaller(IHttpClientFactory clientFactory) {
            this.httpClient = clientFactory.CreateClient();
        }

        /// <summary>
        /// returns card in json from scryfall api
        /// </summary>
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public async Task<MTGCard> GetCard(string id) {
            var response = await httpClient.GetAsync(API_URL + "/cards/" + id);

            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Console.WriteLine(json);

            MTGCard card = Newtonsoft.Json.JsonConvert.DeserializeObject<MTGCard>(json);
            
            return card;// .JsonSerializer.Deserialize<MTGCard>(json, options);
        }

        public async Task<string> GetAllCardSets() {
            var response = await httpClient.GetAsync(API_URL + "/sets");

            return await response.Content.ReadAsStringAsync();        
        }

        public async Task<string> GetAllCards() {
            var response = await httpClient.GetAsync(API_URL + "/bulk-data");

            string json = await response.Content.ReadAsStringAsync();

            dynamic bulkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);

            foreach(var d in bulkdata.data) {
                if(d.type == "all_cards") {
                    response = await httpClient.GetAsync((string)d.download_uri);
                    break;
                }
            }

            return await response.Content.ReadAsStringAsync();
        }

        //endpoint doesnt exist anymore, use bulk 
        //public async Task<string> GetNextCardPage(string nextPageLink = API_URL+"/cards") {
        //    var response = await httpClient.GetAsync(nextPageLink);

        //    return await response.Content.ReadAsStringAsync();
        //}

        public async Task<MemoryStream> GetCardImage(string id) {
            Console.Write("TEST");
            var jsonCard = await GetCard(id);


            var response = await httpClient.GetAsync(jsonCard.ImageUris.Normal);

            byte[] myBytes = await response.Content.ReadAsByteArrayAsync();
            var stream = new MemoryStream(myBytes);

            return stream;
            
        }

        private class AllSetsHelper {

            [JsonProperty("object")]
            public string Object {get;set;}

            [JsonProperty("has_more")]
            public bool Has_more { get; set; }

            [JsonProperty("data")]
            public MTGSet[] Data { get; set; }
        }
    }
}
