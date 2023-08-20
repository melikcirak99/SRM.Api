using Microsoft.EntityFrameworkCore;
using SRM.Api.Entites;
using System.Linq.Expressions;

namespace SRM.Api.Data.Abstract
{
    public interface IRepository<T> where T : EntityBase
    {
        public DbSet<T> Table { get; }

        //read işlemleri
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> method);
        Task<T> GetAsync(Expression<Func<T, bool>> method);
        Task<T> GetAsync(int id);

        //write işlemleri
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        Task<bool> RemoveAsync(T model);
        Task<bool> RemoveAsync(int id);
        Task<bool> RemoveRangeAsync(List<T> datas);
        Task<bool> UpdateAsync(T model);
        Task<bool> SaveAsync();

    }
}
