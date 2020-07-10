using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Data {
    interface ICardData {

        MemoryStream GetImage(MTGCard card);

        ICollection<MTGCard> GetCardsFromSet(string code, string lang); 
    }
}
