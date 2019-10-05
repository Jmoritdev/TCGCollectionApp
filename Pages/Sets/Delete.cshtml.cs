using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Pages.Sets
{
    public class DeleteModel : PageModel
    {
        private readonly TCGCollectionApp.Models.TCGCollectionContext _context;

        public DeleteModel(TCGCollectionApp.Models.TCGCollectionContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MTGSet = await _context.MTGSet.FindAsync(id);

            if (MTGSet != null)
            {
                _context.MTGSet.Remove(MTGSet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
