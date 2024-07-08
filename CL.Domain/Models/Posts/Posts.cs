using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Domain.Models.Posts
{
    public class Posts
    {
        public int Id { get; set; } 
        public string Title { get;set; }
        public string Body { get; set; }
        public DateTime? DatePublished { get;set; }

    }
}
