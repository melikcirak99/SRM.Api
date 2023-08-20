using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SRM.Api.Data;
using SRM.Api.Data.Abstract;
using SRM.Api.Data.Concrete;

namespace SRM.Api.Extensions
{
    public static class ServiceRegistration
    {
        /// <summary>
        /// Dependency İnjection nesnelerini tanımlıyoruz
        /// </summary>
        public static void AddServices(this IServiceCollection services)
        {
            //veritabanı connection stringi alıp context nesnemizi ekliyoruz. 
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            services.AddDbContext<Db>(options =>
            {
                var cstring = configuration.GetConnectionString("SQLiteConnection");
                options.UseSqlite(cstring, x => x.MigrationsHistoryTable("__MyMigrationsHistory", "dbo"));
            });

            //repositoryleri tanımlıyoruz.
            services.AddScoped<IStudentRepository,StudentRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IStudentLessonRepository, StudentLessonRepository>();

        }
    }
}
