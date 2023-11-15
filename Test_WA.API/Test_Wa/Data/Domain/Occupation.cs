using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Test_Wa.Data.Domain
{
    public class Occupation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Emploi")]
        public int EmploiId { get; set; }

        [ForeignKey("EmploiId")]
        [ValidateNever]
        public Emploi Emploi { get; set; }

        [Required]
        [Display(Name = "Personne")]
        public int PersonneId { get; set; }

        [ForeignKey("PersonneId")]
        [ValidateNever]
        public Personne Personne { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }
    }
}
