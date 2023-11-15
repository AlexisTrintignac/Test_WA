using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Test_Wa.Data.Domain
{
    public class Emploi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NomEntreprise { get; set; }
        [Required]
        public string NomPoste { get; set;}
        [JsonIgnore]
        public List<Occupation> Occupations { get; set; }
    }
}
