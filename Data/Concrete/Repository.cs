using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SRM.Api.Data.Abstract;
using SRM.Api.Entites;
using System.Linq.Expressions;

namespace SRM.Api.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly Db _context;
        public Repository(Db context)
        {
            _context = context;
        }
        /// <summary>
        /// veritabanı dbset nesnemizi alıyoruz.
        /// </summary>
        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll()
        {
            var query = Table.AsQueryable();
            return query;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> method)
        {
            var query = Table.Where(method);
            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> method)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(method);
        }


        public async Task<T> GetAsync(int id)
        {
            return await Table.FindAsync(id);
        }
       
        
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry =  await Table.AddAsync(model);
            entityEntry.State = EntityState.Added;
            return await SaveAsync();
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(T model)
        {
            Table.Remove(model);
            return await SaveAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FindAsync(id);
            return await RemoveAsync(model);
        }
        public async Task<bool> RemoveRangeAsync(List<T> datas)
        {
            Table.RemoveRange(datas);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(T model)
        {
            //entity framework tarafından tracking mekanizması yardımı ile takip edilmeyen nesnelerin güncellendikten sonra kaydedilmesi için kullanılır. tracking mekanizması ile takip edilen nesnelerde ilgili context nesnesi aracılığı ile SaveChanges() metodunun çağrılması yeterlidir.
            EntityEntry<T> entityEntry = Table.Update(model);
            entityEntry.State = EntityState.Modified;   
            return await SaveAsync();
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
