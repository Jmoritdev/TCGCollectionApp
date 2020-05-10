using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Pages.Cards
{
    public class IndexModel : PageModel
    {
        private readonly TCGCollectionContext _context;
        private readonly Services.ApiCallerMTG _apiCaller;

        public IndexModel(TCGCollectionContext context, Services.ApiCallerMTG apiCaller)
        {
            _context = context;
            _apiCaller = apiCaller;
            SaveAllCards();
        }

        public IList<MTGCard> MTGCard { get;set; }

        public async Task OnGetAsync()
        {
            //MTGCard = await _context.MTGCard.ToListAsync();
        }

        public void SaveAllCardSets() {
            string json = _apiCaller.GetAllCardSets().Result;

            AllSetsHelper helper = Newtonsoft.Json.JsonConvert.DeserializeObject<AllSetsHelper>(json);

            foreach (MTGSet set in helper.Data) {
                _context.MTGSet.Add(set);
            }

            _context.SaveChanges();
        }

        public void SaveAllCards() {
            string json = _apiCaller.GetNextCardPage().Result;
            CardPageHelper helper = Newtonsoft.Json.JsonConvert.DeserializeObject<CardPageHelper>(json);

            do {
                foreach(MTGCard card in helper.Data) {
                    _context.MTGCard.Add(card);
                }

                _context.SaveChanges();
                json = _apiCaller.GetNextCardPage(helper.NextPage).Result;
                helper = Newtonsoft.Json.JsonConvert.DeserializeObject<CardPageHelper>(json);
            } while (helper.Has_more);
        }

        public void GetCardImage()
        {
            
            Console.WriteLine("lmao");
        }

        private class AllSetsHelper {

            [JsonProperty("object")]
            public string Object { get; set; }

            [JsonProperty("has_more")]
            public bool Has_more { get; set; }

            [JsonProperty("data")]
            public MTGSet[] Data { get; set; }
        }

        private class CardPageHelper {
            [JsonProperty("object")]
            public string Object { get; set; }

            [JsonProperty("total_cards")]
            public int TotalCards { get; set; }

            [JsonProperty("has_more")]
            public bool Has_more { get; set; }

            [JsonProperty("next_page")]
            public string NextPage { get; set; }

            [JsonProperty("data")]
            public MTGCard[] Data { get; set; }
        }
    }
}
