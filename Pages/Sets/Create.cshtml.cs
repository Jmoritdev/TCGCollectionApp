using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Pages.Sets
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
        public MTGSet MTGSet { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MTGSet.Add(MTGSet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}