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
    public class DeleteModel : PageModel
    {
        private readonly TCGCollectionApp.Models.TCGCollectionContext _context;

        public DeleteModel(TCGCollectionApp.Models.TCGCollectionContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MTGCard = await _context.MTGCard.FindAsync(id);

            if (MTGCard != null)
            {
                _context.MTGCard.Remove(MTGCard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
