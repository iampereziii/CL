using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst
{
    public class Video
    {
        public Video()
        {
          
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genres { get; set; }
        public ClassificationEnum Classification { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
