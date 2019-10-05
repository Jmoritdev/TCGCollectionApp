using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Pages.Sets
{
    public class EditModel : PageModel
    {
        private readonly TCGCollectionApp.Models.TCGCollectionContext _context;

        public EditModel(TCGCollectionApp.Models.TCGCollectionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MTGSet MTGSet { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MTGSet = await _context.MTGSet.FirstOrDefaultAsync(m => m.ID == id);

            if (MTGSet == null)
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

            _context.Attach(MTGSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MTGSetExists(MTGSet.ID))
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

        private bool MTGSetExists(string id)
        {
            return _context.MTGSet.Any(e => e.ID == id);
        }
    }
}
