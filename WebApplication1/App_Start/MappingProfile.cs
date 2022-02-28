using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DTOS;
using WebApplication1.Models;

namespace WebApplication1.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }
    }
}