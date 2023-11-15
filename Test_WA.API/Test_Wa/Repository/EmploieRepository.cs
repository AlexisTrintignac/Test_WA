using Test_Wa.Data;
using Test_Wa.Data.Domain;
using Test_Wa.Data.Dto;
using Test_Wa.Repository.Interface;

namespace Test_Wa.Repository
{
    public class EmploiRepository : IEmploiRepository
    {
        private ApplicationDbContext _dbContext;

        public EmploiRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(CreateEmploi emploi)
        {
            Emploi em = new Emploi
            {
                Id =  0,
                NomEntreprise = emploi.NomEntreprise,
                NomPoste = emploi.NomPoste,
            };
            await this._dbContext.Emploi.AddAsync(em);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
