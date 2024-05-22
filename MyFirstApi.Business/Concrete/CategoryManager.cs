using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MyFirstApi.Business.Abstract;
using MyFirstApi.Core.Utilities.Results.Abstract;
using MyFirstApi.Core.Utilities.Results.Concrete.ErrorResult;
using MyFirstApi.Core.Utilities.Results.Concrete.SuccessResult;
using MyFirstApi.DataAccess.Abstract;
using MyFirstApi.Entities.Concrete;
using MyFirstApi.Entities.Dtos.CategoryDtos;
using Serilog;

namespace MyFirstApi.Business.Concrete;

public class CategoryManager(ICategoryDal categoryDal, IMapper mapper) : ICategoryService
{
    private readonly ICategoryDal _categoryDal = categoryDal;
    private readonly IMapper _mapper = mapper;


    public IResult CreateCategory(CategoryAddDto category)
    {
        try
        {
            var mapper = _mapper.Map<Category>(category);
            _categoryDal.Add(mapper);
            return new SuccessResult(HttpStatusCode.Created, "Category elave olundu.");
        }
        catch (Exception e)
        {
            return new ErrorResult(HttpStatusCode.BadRequest, e.Message);
        }
    }


    public IDataResult<List<Category>> GetAll()
    {
     
        var res = _categoryDal.GetAll();
        return new SuccessDataResult<List<Category>>(res, HttpStatusCode.Created);
    }
}
