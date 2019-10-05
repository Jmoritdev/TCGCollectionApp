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
    public class IndexModel : PageModel
    {
        private readonly TCGCollectionApp.Models.TCGCollectionContext _context;

        public IndexModel(TCGCollectionApp.Models.TCGCollectionContext context)
        {
            _context = context;
        }

        public IList<MTGCard> MTGCard { get;set; }

        public async Task OnGetAsync()
        {
            MTGCard = await _context.MTGCard.ToListAsync();
        }
    }
}
