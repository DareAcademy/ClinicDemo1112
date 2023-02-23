using Microsoft.EntityFrameworkCore;

namespace ClinicDemo1112.data
{
    public class ClinicContext:DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost; initial catalog=ClinicDemoDb1112; integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
