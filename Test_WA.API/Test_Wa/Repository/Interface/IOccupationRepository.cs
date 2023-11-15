using Test_Wa.Data.Dto;

namespace Test_Wa.Repository.Interface
{
    public interface IOccupationRepository
    {
        Task Add(CreateOccupation occupation);
    }
}
