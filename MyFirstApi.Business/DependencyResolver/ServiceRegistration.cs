using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyFirstApi.Business.Abstract;
using MyFirstApi.Business.AutoMapper;
using MyFirstApi.Business.Concrete;
using MyFirstApi.Business.Validator;
using MyFirstApi.DataAccess.Abstract;
using MyFirstApi.DataAccess.Concrete;
using MyFirstApi.Entities.Concrete;
using MyFirstApi.Entities.Dtos.CategoryDtos;

namespace MyFirstApi.Business.DependecyResolver;

public static class ServiceRegistration
{
    public static void AddServiceRegistiration(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();

        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<ICategoryService, CategoryManager>();
        
        services.AddScoped<ITodoDal, EfTodoDal>();

        services.AddAutoMapper(typeof(MappingProfile));

        
        
    }
}
