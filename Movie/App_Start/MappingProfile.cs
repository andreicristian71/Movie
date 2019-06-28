using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Movie.Models;
using Movie.Dtos;

namespace Movie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Models.Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Models.Movie>();
        }
    }
}