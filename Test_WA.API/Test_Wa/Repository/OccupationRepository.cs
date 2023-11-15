using Test_Wa.Data;
using Test_Wa.Data.Domain;
using Test_Wa.Data.Dto;
using Test_Wa.Repository.Interface;

namespace Test_Wa.Repository
{
    public class OccupationRepository : IOccupationRepository
    {
        private ApplicationDbContext _dbContext;

        public OccupationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(CreateOccupation occupation)
        {
            Occupation newOccupation = new Occupation
            {
                Id = 0,
                EmploiId = occupation.EmploiId,
                PersonneId = occupation.PersonneId,
                DateDebut = occupation.DateDebut,
                DateFin = occupation.DateFin,
            };
            await this._dbContext.Occupation.AddAsync(newOccupation);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
