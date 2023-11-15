using Test_Wa.Data.Domain;
using Test_Wa.Data.Dto;

namespace Test_Wa.Repository.Interface
{
    public interface IEmploiRepository
    {
        Task Add(CreateEmploi emploi);

        Task<List<Emploi>> GetEmploieByPersonneAndDate(int personneId, DateTime dateDebut, DateTime datefin);
    }
}
