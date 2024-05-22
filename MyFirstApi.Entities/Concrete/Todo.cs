using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstApi.Core.Entities.Abstract;

namespace MyFirstApi.Entities.Concrete;

public class Todo : BaseEntity, IEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
