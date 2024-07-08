using CL.Domain.Dtos.Movies;
using System;
using System.ComponentModel.DataAnnotations;

namespace CL.Domain.Movies.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string MovieName { get; set; }

        public string MovieDetails { get; set; }

        [Required]
        public DateTime? ReleasedDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int Stocks { get; set; }

        public GenreDto Genre { get; set; }
    }

}
