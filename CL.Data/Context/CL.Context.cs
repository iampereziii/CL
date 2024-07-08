using CL.Domain.Models;
using CL.Domain.Models.ApplicationUser;
using CL.Domain.Models.Customers;
using CL.Domain.Models.Movies;
using CL.Domain.Models.Rents;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CL.Data.Context
{
    public class CLContext : IdentityDbContext<ApplicationUser>
    {
        public CLContext() : base("CLContext", throwIfV1Schema: false)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }

        public DbSet<MembershipType> MembershipType { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Rental> Rental { get; set; }

        public static CLContext Create()
        {
            return new CLContext();
        }
    }

}
