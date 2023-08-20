using Microsoft.EntityFrameworkCore;
using SRM.Api.Data.Abstract;
using SRM.Api.Entites;
using System.Linq.Expressions;

namespace SRM.Api.Data.Concrete
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(Db context) : base(context)
        {
        }

        /// <summary>
        /// öğrencileri profil doluluk oranına göre sıralayarak yükleme metodumuz
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllOrderByRank()
        {
            var models = Table
                .Include(x=>x.StudentLessons)
                .Include(x=>x.Grades)
                .AsEnumerable()
                .OrderByDescending(x => x.CalculateRanking());
            return models.ToList();
        }

        /// <summary>
        /// listeleme sırasında bir linq  sorgusu eklenmesine izin veren overload.
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllOrderByRank(Expression<Func<Student, bool>> method)
        {
            var models = Table
                .Include(x => x.StudentLessons)
                .Include(x => x.Grades)
                .Where(method)
                .AsEnumerable()
                .OrderByDescending(x => x.CalculateRanking());
            return models.ToList();
        }
    }
}
