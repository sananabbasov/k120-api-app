using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstApi.Core.Repositories.Concrete.EntityFramework;
using MyFirstApi.DataAccess.Abstract;
using MyFirstApi.Entities.Concrete;

namespace MyFirstApi.DataAccess.Concrete;

public class EfTodoDal : EfRepositoryBase<Todo, AppDbContext>, ITodoDal
{
}
