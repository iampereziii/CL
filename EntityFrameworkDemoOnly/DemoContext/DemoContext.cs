using System.Data.Entity;
using CL.Domain.Models.Posts;

namespace EntityFrameworkDemo.DemoContext
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("CLContext")
        { }
        public DbSet<Posts> Posts { get; set; }
    }
}
