using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Core.Entities.Abstract;
using MyFirstApi.Core.Repositories.Abstract;

namespace MyFirstApi.Core.Repositories.Concrete.EntityFramework;

public class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
where TEntity : class, IEntity
where TContext : DbContext, new()
{
    public void Add(TEntity entity)
    {
        using var context = new TContext();
        var addEntity = context.Entry(entity);
        addEntity.State = EntityState.Added;
        context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        using var context = new TContext();
        var removeEntity = context.Entry(entity);
        removeEntity.State = EntityState.Deleted;
        context.SaveChanges();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using var context = new TContext();
        return context.Set<TEntity>().FirstOrDefault(filter);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        using var context = new TContext();
        return filter == null
        ? context.Set<TEntity>().ToList()
        : context.Set<TEntity>().Where(filter).ToList();
    }

    public void Update(TEntity entity)
    {
        using var context = new TContext();
        var updateEntity = context.Entry(entity);
        updateEntity.State = EntityState.Modified;
        context.SaveChanges();
    }
}
