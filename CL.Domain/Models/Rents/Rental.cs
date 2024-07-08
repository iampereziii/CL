using CL.Domain.Models.Customers;
using CL.Domain.Models.Movies;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CL.Domain.Models.Rents
{
    public class Rental
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Movie Movie { get; set; }
        public DateTime? DateReturned { get; set; }
        public DateTime DateRented { get; set; }

    }
}
