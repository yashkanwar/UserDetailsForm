using Microsoft.EntityFrameworkCore;
using UserDetailsForm.Models;

namespace UserDetailsForm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
