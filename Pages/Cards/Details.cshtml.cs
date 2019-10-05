using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Pages.Cards
{
    public class DetailsModel : PageModel
    {
        private readonly TCGCollectionApp.Models.TCGCollectionContext _context;

        public DetailsModel(TCGCollectionApp.Models.TCGCollectionContext context)
        {
            _context = context;
        }

        public MTGCard MTGCard { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MTGCard = await _context.MTGCard.FirstOrDefaultAsync(m => m.ID == id);

            if (MTGCard == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
