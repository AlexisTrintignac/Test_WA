using Test_Wa.Data.Domain;
using Test_Wa.Data.Dto;

namespace Test_Wa.Repository.Interface
{
    public interface IPersonneRepository
    {
        Task Add(CreatePersonne personne);

        Task<List<PersonneDetails>> GetAllDetails();

        Task<List<PersonneDetails>> GetPersonnesByEntreprise(string nomEntreprise);

        Task<List<Personne>> GetPersonnesWithoutEmploi(DateTime dateDebut, DateTime datefin);

        Task<List<Personne>> GetPersonnesWithEmploi(DateTime dateDebut, DateTime datefin);
    }
}
