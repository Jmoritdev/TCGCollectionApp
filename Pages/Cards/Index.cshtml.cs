using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TCGCollectionApp.Data;
using TCGCollectionApp.Models;
using TCGCollectionApp.Services;

namespace TCGCollectionApp.Pages.Cards
{
    public class IndexModel : PageModel {
        private readonly MTGCardData cardData;
        private readonly MTGSetData setData;
        private readonly MTGApiCaller apiCaller;

        public IndexModel(MTGCardData cardData, MTGSetData setData, MTGApiCaller apiCaller) {
            this.cardData = cardData;
            this.setData = setData;
            this.apiCaller = apiCaller;
        }

        public ICollection<MTGSet> Sets { get; set; }

        public void OnGetAsync() {
            Sets = setData.GetSets();
        }

        public JsonResult OnGetCardsFromSet(string code, string lang) {
            var json = System.Text.Json.JsonSerializer.Serialize(cardData.GetCardsFromSet(code, lang));

            return new JsonResult(json);
        }
    }
}
