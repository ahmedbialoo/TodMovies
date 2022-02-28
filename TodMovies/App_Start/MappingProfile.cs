using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodMovies.Dtos;
using TodMovies.DTOS;
using TodMovies.Models;

namespace TodMovies.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MemberShipType, MembershipTypeDTO>();
            Mapper.CreateMap<Movie,MovieDTO>();
            Mapper.CreateMap<Genre,GenreDTO>();

            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(n => n.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO,Movie>().ForMember(n=>n.Id,opt=>opt.Ignore());

            
        }
    }
}