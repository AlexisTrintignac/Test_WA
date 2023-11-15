using Microsoft.EntityFrameworkCore;
using Test_Wa.Data.Domain;

namespace Test_Wa.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Personne> Personne { get; set; } 
            
        public DbSet<Emploi> Emploi { get; set; }

        public DbSet<Occupation> Occupation { get; set; }

    }
}
