using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Domain.Models.Movies
{
    public class MovieFormViewModel
    {

        public Movie Movie{ get; set; }
        public IEnumerable<Genre> GenreModel { get; set; }
        [Display(Name ="Genre")]
        [Required]
        public int GenreId { get; set; }
    }
}
