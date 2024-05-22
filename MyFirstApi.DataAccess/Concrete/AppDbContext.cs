using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Entities.Concrete;

namespace MyFirstApi.DataAccess.Concrete;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=K120TodoListDb; User Id=SA; Password=Ehmed123; TrustServerCertificate=True;");
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Todo> Todos { get; set; }



    public override int SaveChanges()
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            switch (data.State)
            {
                case EntityState.Added:
                    data.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    data.Entity.UpdateDate = DateTime.Now;
                    break;
                default:
                    data.Entity.CreatedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChanges();
    }
}
