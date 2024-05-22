using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MyFirstApi.Entities.Concrete;
using MyFirstApi.Entities.Dtos.CategoryDtos;

namespace MyFirstApi.Business.Validator;

public class CategoryValidator : AbstractValidator<CategoryAddDto>
{
    public CategoryValidator()
    {
        RuleFor(x=>x.Name).MinimumLength(3).WithMessage("Category adin bos qoymaq olmaz");
    }
}
