using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCGCollectionApp.Models {
    public class MTGCard {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(3, MinimumLength = 2)]
        [Required]
        public string LanguageCode { get; set; }

        [Display(Name = "Oracle ID")]
        [Required]
        public string OracleID { get; set; }

        [Display(Name = "Set ID")]
        [Required]
        public MTGSet Set { get; set; }

        [Display(Name = "Is Foil")]
        public bool IsFoil { get; set; } = false;
    }
}
