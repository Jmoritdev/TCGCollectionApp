using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Pages.Cards
{
    public class CreateModel : PageModel
    {
        private readonly TCGCollectionApp.Models.TCGCollectionContext _context;

        public CreateModel(TCGCollectionApp.Models.TCGCollectionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MTGCard MTGCard { get; set; }

        public async Task<IActionResult> OnPostAsync(string setId)
        {
            MTGSet set = _context.MTGSet.Find(setId);

            if(set == null) {
                return Page();
            }

            MTGCard.Set = set;

            //TODO validation
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.MTGCard.Add(MTGCard);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}