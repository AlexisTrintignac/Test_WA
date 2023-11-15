using Microsoft.EntityFrameworkCore;
using Test_Wa.Data;
using Test_Wa.Data.Domain;
using Test_Wa.Data.Dto;
using Test_Wa.Repository.Interface;

namespace Test_Wa.Repository
{
    public class PersonneRepository : IPersonneRepository
    {
        private ApplicationDbContext _dbContext;

        public PersonneRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(CreatePersonne personne)
        {
           
            int age = DateTime.Now.Year - personne.DateNaissance.Year;

            if (DateTime.Now < personne.DateNaissance.AddYears(age))
            {
                age--;
            }

            // Vérifier si l'âge est supérieur à 100 ans
            if(age >= 100)
            {
                throw new Exception("la personne doit avoir moins de 100 ans !");
            }

            Personne newPersonne = new Personne
            {
                Id = 0,
                Nom = personne.Nom,
                Prenom = personne.Prenom,
                DateNaissance = personne.DateNaissance,
            };

            await this._dbContext.Personne.AddAsync(newPersonne);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<List<PersonneDetails>> GetAllDetails()
        {
            List<PersonneDetails> personneDetails = new List<PersonneDetails>();
            List<Personne> personnes = await this._dbContext.Personne.Select(p => p).Include(p=> p.Occupations).ThenInclude(occ => occ.Emploi).ToListAsync();

            personnes.ForEach(personne =>
            {

                PersonneDetails p = new PersonneDetails
                {
                    Id = personne.Id,
                    Nom = personne.Nom,
                    Prenom = personne.Prenom,
                    age = DateTime.Now.Year - personne.DateNaissance.Year,
                    emploies = personne.Occupations.Select(occ => occ.Emploi).ToList(),
                };

                personneDetails.Add(p);
            });
            return personneDetails.OrderBy(p => p.Nom).ToList();
        }
    }
}
