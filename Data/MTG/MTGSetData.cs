using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TCGCollectionApp.Models;
using TCGCollectionApp.Services;

namespace TCGCollectionApp.Data {
    public class MTGSetData : ISetData {

        private readonly TCGCollectionContext _context;
        private readonly MTGApiCaller apiCaller;

        public MTGSetData(TCGCollectionContext _context, MTGApiCaller apiCaller) {
            this._context = _context;
            this.apiCaller = apiCaller;
        }

        public ICollection<MTGSet> GetSets() {
            return _context.MTGSet.OrderBy(s => s.Name).ToList();
        }

        public void AddSet(MTGSet set) {
            _context.MTGSet.Add(set);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public void UpdateSet(MTGSet set) {
            _context.MTGSet.Add(set).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void SaveIconForSet(MTGSet set) {
            byte[] image = apiCaller.GetSetIcon(set).Result;

            if (image != null) {
                set.IconSvgBase64 = Convert.ToBase64String(image);
            }
        }
    }
}
