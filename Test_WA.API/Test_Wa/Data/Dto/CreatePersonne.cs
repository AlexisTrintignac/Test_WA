using System.ComponentModel.DataAnnotations;

namespace Test_Wa.Data.Dto
{
    public class CreatePersonne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
    }
}
