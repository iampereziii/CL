using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst
{
    public class Tag
    {
        public Tag() {
            Videos = new List<Video>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Video> Videos { get; set; }
        
    }
}
