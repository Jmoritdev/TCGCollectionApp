using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Data {
    /**
     * DAL Layer for MTGCard Database
     */
    public class MTGCardData : ICardData {

        private readonly TCGCollectionContext _context;

        public MTGCardData(TCGCollectionContext _context) {
            this._context = _context;
        }

        public ICollection<MTGCard> GetCardsFromSet(string code, string lang) {
            return _context.MTGCard.Where(c => c.Set == code && c.Lang == lang).Include(c => c.ImageUris).OrderBy(t => t.Name).ToList();
        }

        public MemoryStream GetImage(MTGCard card) {
            throw new NotImplementedException();
        }
    }
}
