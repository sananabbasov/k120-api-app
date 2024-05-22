using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Api.Models;
using MyFirstApi.Business.Abstract;
using MyFirstApi.Core.Utilities.Results.Abstract;
using MyFirstApi.Entities.Dtos.CategoryDtos;

namespace MyFirstApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{

    private readonly ICategoryService _categoryService;
    private readonly IHttpContextAccessor _httpContext;

    private readonly ILogger<IDataResult<List<Category>>> _logger;

    public CategoryController(ICategoryService categoryService, IHttpContextAccessor httpContext, ILogger<IDataResult<List<Category>>> logger)
    {
        _categoryService = categoryService;
        _httpContext = httpContext;
        _logger = logger;
    }


    [HttpPost("create")]
    public IActionResult Create([FromBody] CategoryAddDto category)
    {
        

       var res =  _categoryService.CreateCategory(category);
        return Ok(res);
    }

    [HttpGet("get")]
    public IActionResult Get()
    {
     _logger.LogInformation("Seri Log is Working. Salam");

        var res = _categoryService.GetAll();
        return Ok(res);
    }



}
