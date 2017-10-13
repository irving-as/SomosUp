using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AcopioUP.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Victim> Victims { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Donation> Donations { get; set; }

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