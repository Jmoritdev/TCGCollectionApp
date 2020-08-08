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

        public ICollection<MTGCard> GetAll() {
            return _context.MTGCard.ToList();
        }

        public void AddCard(MTGCard card) {
            _context.MTGCard.Add(card);
        }

        public void AddMultiple(ICollection<MTGCard> cards) {
            _context.MTGCard.AddRange(cards);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public void UpdateCard(MTGCard card) {
            _context.MTGCard.Add(card).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public HashSet<string> GetAllIds() {
            return _context.MTGCard.Select(c => c.Id).ToHashSet<string>();
        }

        public IQueryable<MTGUserCard> GetCardsForUser(string userId) {
            return (from usercard in _context.MTGUserCard
                   join card in _context.MTGCard on usercard.CardId equals card.Id
                   where usercard.UserId == userId
                   select usercard).Include(c => c.Card.ImageUris);
        }

        public IQueryable<MTGSet> GetSetsForCard(string cardName) { 
            return _context.MTGSet.Where(s => s.Cards.Select(c => c.Name).Contains(cardName));
        }

        public ICollection<string> GetLanguagesForCardInSet(string cardName, string setCode) {
            return _context.MTGCard.Where(c => c.Name == cardName && c.Set == setCode).Select(c => c.Lang).Distinct().ToList();
        }

        public MTGCard SearchForCard(string cardName, string lang, string setCode) {
            return _context.MTGCard.Where(c => c.Name == cardName && c.Lang == lang && c.Set == setCode).FirstOrDefault();
        }

        public bool AddToCollection(MTGUserCard collectionItem) {

            MTGUserCard existingCard = _context.MTGUserCard.FirstOrDefault(uc => uc.UserId == collectionItem.UserId && uc.CardId == collectionItem.CardId);
            if (existingCard == null) {
                _context.MTGUserCard.Add(collectionItem);
            } else {
                existingCard.Amount += collectionItem.Amount;
            }

            return (_context.SaveChanges() == 1);
        }
    }
}
