using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyFirstApi.Entities.Concrete;
using MyFirstApi.Entities.Dtos.CategoryDtos;

namespace MyFirstApi.Business.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryAddDto, Category>();
    }
}
