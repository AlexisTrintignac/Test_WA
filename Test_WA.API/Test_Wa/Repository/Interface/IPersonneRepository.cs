using Test_Wa.Data.Dto;

namespace Test_Wa.Repository.Interface
{
    public interface IPersonneRepository
    {
        Task Add(CreatePersonne personne);

        Task<List<PersonneDetails>> GetAllDetails();
    }
}
