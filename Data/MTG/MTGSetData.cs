using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Data {
    public class MTGSetData : ISetData {

        private readonly TCGCollectionContext _context;

        public MTGSetData(TCGCollectionContext _context) {
            this._context = _context;
        }

        public ICollection<MTGSet> GetSets() {
            return _context.MTGSet.OrderBy(s => s.Name).ToList();
        }
    }
}
