using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Domain.Models.Movies
{

    public class Movie
    {
        public Movie()
        {
            DateAdded = DateTime.Now;

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Movie Title")]
        [Required]
        public string MovieName { get; set; }

        public string MovieDetails { get; set; }

        [Display(Name = "Released Date")]
        [Required]
        public DateTime? ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int Stocks { get; set; }
        public int StocksAvailable { get; set; }

        public Genre Genre { get; set; }
    }
}
