using AutoMapper;
using CL.Domain.Dtos.Movies;
using CL.Domain.Models.Customers;
using CL.Domain.Models.Movies;
using CL.Domain.Models.Rents;
using CL.Domain.Movies.Dtos;

namespace CL.Web.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieDto>();

            CreateMap<RentDto, Rental>();
            CreateMap<Rental, RentDto>();

            CreateMap<GenreDto, Genre>();
            CreateMap<Genre, GenreDto>();

            //Create Customer DTO
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}