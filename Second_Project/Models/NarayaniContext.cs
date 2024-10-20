using Microsoft.EntityFrameworkCore;

namespace Second_Project.Models
{
 
        public class NarayaniContext : DbContext
        {
            public DbSet<Doctor> Doctors { get; set; }
            public NarayaniContext(DbContextOptions<NarayaniContext> options)
                : base(options)
            {
            }
        }
}
