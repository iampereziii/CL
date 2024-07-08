using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst
{
    public class Genre
    {
        public Genre()
        {
            Videos = new HashSet<Video>();
        }
        public int Id { get; set; }
        public string Name { get; set; }    

        public ICollection<Video> Videos { get; set; }
    }
}
