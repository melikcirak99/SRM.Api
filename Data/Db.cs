using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SRM.Api.Entites;

namespace SRM.Api.Data
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //veritabanı ile aynı isimde bir schema oluşturlmasını engelliyoruz.
            modelBuilder.HasDefaultSchema("dbo");

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //veritabanında ekleme veya güncelleme işlemleri yapılırken araya girip ekleme ve güncelleme tarihlerini otomatik eklettiriyoruz.
            var datas = ChangeTracker.Entries<EntityBase>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow.ToLocalTime(),
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow.ToLocalTime(),
                    _ => DateTime.UtcNow.ToLocalTime()
                };
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<EntityBase>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow.ToLocalTime(),
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow.ToLocalTime(),
                    _ => DateTime.UtcNow.ToLocalTime()
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
