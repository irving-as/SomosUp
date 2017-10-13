using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AcopioUP.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Victim> Victims { get; set; }

        public DbSet<CollectionCenter> CollectionCenters { get; set; }

        //public DbSet<Donation> Donations { get; set; } TODO: Uncomment when CollectionCenter Model is added

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}