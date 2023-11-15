using Test_Wa.Data.Domain;

namespace Test_Wa.Data.Dto
{
    public class PersonneDetails
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public int age{ get; set; }

        public List<Emploi> emploies { get; set; }

/*        public string nomEntreprise { get; set; }
*/
    }
}
