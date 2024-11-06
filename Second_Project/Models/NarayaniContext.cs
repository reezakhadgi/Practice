using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Second_Project.Models
{
 
        public class NarayaniContext : IdentityDbContext<IdentityUser>
    {
            public DbSet<Doctor> Doctors { get; set; }
            public DbSet<Patient> Patients { get; set; }
        public NarayaniContext(DbContextOptions<NarayaniContext> options)
                : base(options)
            {
           
            }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the one-to-many relationship between Doctor and Patient
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.DoctorId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
