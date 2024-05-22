using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstApi.Core.Entities.Abstract;

namespace MyFirstApi.Entities.Concrete;

public class Category : BaseEntity, IEntity
{
    public string Name { get; set; }
}
