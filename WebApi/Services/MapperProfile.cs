using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Add Mapping profiles here.... Model->Model

            CreateMap<PlantItemDTO, PlantItem>();
        }
    }
}