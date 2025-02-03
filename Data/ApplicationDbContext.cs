using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shirish_Tripathi_Dot_Net_Assignment.Models;

namespace Shirish_Tripathi_Dot_Net_Assignment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Shirish_Tripathi_Dot_Net_Assignment.Models.ReviewSubmit> ReviewSubmit { get; set; } = default!;
        


    }
}
