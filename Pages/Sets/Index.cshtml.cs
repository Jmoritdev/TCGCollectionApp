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
    public class IndexModel : PageModel
    {
        private readonly TCGCollectionApp.Data.TCGCollectionContext _context;

        public IndexModel(TCGCollectionApp.Data.TCGCollectionContext context)
        {
            _context = context;
        }

        public IList<MTGSet> MTGSet { get;set; }

        public async Task OnGetAsync()
        {
            MTGSet = await _context.MTGSet.ToListAsync();
        }
    }
}
