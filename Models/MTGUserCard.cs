using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCGCollectionApp.Data;

namespace TCGCollectionApp.Models
{
    public class MTGUserCard {

        public string UserId { get; set; }

        public string CardId { get; set; }

        public User User { get; set; }

        public MTGCard Card { get; set; }

        public int Amount { get; set; }

        public bool Signed { get; set; }
    }
}
