using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using VidzyCodeFirst.EntityConfigurations;

namespace VidzyCodeFirst
{
    public partial class VidzyCodeFirstContext : DbContext
    {
        public VidzyCodeFirstContext()
            : base("name=VidzyCodeFirstContext")
        {
        }

        DbSet<Video> Videos { get; set; }
        DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());  
        }
    }
}
