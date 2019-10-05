using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCGCollectionApp.Models {
    public class MTGSet {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<MTGCard> Cards { get; set; }
    }
}
