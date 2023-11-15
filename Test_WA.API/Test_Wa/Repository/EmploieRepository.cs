using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<Emploi>> GetEmploieByPersonneAndDate(int personneId, DateTime dateDebut, DateTime datefin)
        {
            List<Emploi> emploi = await this._dbContext.Emploi.Where(emp => emp.Occupations.Any(occ => occ.DateDebut >= dateDebut &&
                                                                                            occ.DateFin <= datefin &&
                                                                                            occ.PersonneId == personneId))
                                                              .ToListAsync();
            return emploi;
        }
    }
}
