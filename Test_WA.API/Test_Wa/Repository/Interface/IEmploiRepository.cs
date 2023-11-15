using Test_Wa.Data.Domain;
using Test_Wa.Data.Dto;

namespace Test_Wa.Repository.Interface
{
    public interface IEmploiRepository
    {
        Task Add(CreateEmploi emploi);
    }
}
