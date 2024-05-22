using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstApi.Core.Utilities.Results.Abstract;
using MyFirstApi.Entities.Concrete;
using MyFirstApi.Entities.Dtos.CategoryDtos;

namespace MyFirstApi.Business.Abstract
{
    public interface ICategoryService
    {
        IResult CreateCategory(CategoryAddDto category);

        IDataResult<List<Category>> GetAll();
    }

}

