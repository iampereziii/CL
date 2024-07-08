using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst.EntityConfigurations
{
    public class VideoConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            Property(x => x.Name).IsRequired();
            Property(x => x.GenreId).IsRequired();
            Property(x=>x.Classification).HasColumnType("tinyint");

            HasRequired(x => x.Genres).WithMany(x => x.Videos)
                .HasForeignKey(x => x.GenreId);

            HasMany(x => x.Tags).WithMany(x => x.Videos).Map(m =>
            {
                m.ToTable("VideoTags");
                m.MapLeftKey("VideoId");
                m.MapRightKey("TagId");
            });

        }
    }
}
