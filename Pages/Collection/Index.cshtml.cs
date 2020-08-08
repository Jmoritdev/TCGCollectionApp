using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Internal;
using TCGCollectionApp.Data;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Pages.Collection {
    public class IndexModel : PageModel {
        private readonly MTGCardData cardData;
        private readonly HttpContext httpContext;

        public ICollection<MTGCard> UserCards { get; set; }

        public IndexModel(MTGCardData cardData, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContext) {
            this.cardData = cardData;
            this.httpContext = httpContext.HttpContext;
        }

        public void OnGet() {
        }

        public JsonResult OnGetUserCards() {
            var json = "";

            if (httpContext.User.Identity.IsAuthenticated) {
                string userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
         
                json = JsonSerializer.Serialize(cardData.GetCardsForUser(userId));
            }
            
            return new JsonResult(json);
        }

        public JsonResult OnGetSetsForCard(string cardName) {
            return new JsonResult(cardData.GetSetsForCard(cardName).Select(s => new { s.Code, s.Name }));
        }

        public JsonResult OnGetLanguagesForCardInSet(string cardName, string setCode) {
            return new JsonResult(cardData.GetLanguagesForCardInSet(cardName, setCode).OrderByDescending(l => l == "en").ThenBy(l => l));
        }

        public IActionResult OnPostAddToCollection(string cardName, string lang, string setCode, int amount, bool isSigned = false, bool isFoil = false) {
            MTGCard searchedCard = cardData.SearchForCard(cardName, lang, setCode);

            if (searchedCard != null) {
                MTGUserCard c = new MTGUserCard();
                c.CardId = searchedCard.Id;
                c.UserId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                c.Amount = amount;
                c.Signed = isSigned;
                c.Foil = isFoil;

                if (cardData.AddToCollection(c)) {
                    return StatusCode(201, "Successfully added " + cardName + " to collection");
                } else {
                    return StatusCode(500, "Internal Server error, try again later");
                }
            }

            return StatusCode(500, "Internal Server error, try again later");
        }
    }
}