using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Pages.Cards
{
    public class EditModel : PageModel
    {
        private readonly TCGCollectionApp.Models.TCGCollectionContext _context;

        public EditModel(TCGCollectionApp.Models.TCGCollectionContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MTGCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MTGCardExists(MTGCard.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MTGCardExists(string id)
        {
            return _context.MTGCard.Any(e => e.ID == id);
        }
    }
}
