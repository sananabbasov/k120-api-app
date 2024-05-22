using MyFirstApi.Core.Repositories.Abstract;
using MyFirstApi.Entities.Concrete;



namespace MyFirstApi.DataAccess.Abstract
{
    public interface ITodoDal : IRepositoryBase<Todo>
    {
    }
}
