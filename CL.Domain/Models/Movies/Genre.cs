using System.ComponentModel.DataAnnotations;

namespace CL.Domain.Models.Movies
{
    public class Genre
    {
        [Required(ErrorMessage = "Genre is required")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
