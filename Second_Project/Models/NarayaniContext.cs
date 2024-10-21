using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Second_Project.Models
{
 
        public class NarayaniContext : IdentityDbContext<IdentityUser>
    {
            public DbSet<Doctor> Doctors { get; set; }
            public NarayaniContext(DbContextOptions<NarayaniContext> options)
                : base(options)
            {
           
            }
    }
}
