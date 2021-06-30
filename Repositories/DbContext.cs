using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DbContext : IdentityDbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<County> County { get; set; }
        public DbSet<Locality> Locality { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Allergy> Allergy { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientService> PatientService { get; set; }
        public DbSet<PatientAllergy> PatientAllergy { get; set; }
    }
}
