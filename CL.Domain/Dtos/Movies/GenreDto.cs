using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Domain.Dtos.Movies
{
    public class GenreDto
    {

        //[Required(ErrorMessage = "Genre is required")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
