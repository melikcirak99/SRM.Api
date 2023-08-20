using SRM.Api.Entites;
using System.Linq.Expressions;

namespace SRM.Api.Data.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        /// <summary>
        /// öğrencileri profil doluluk oranına göre listeleme metodumuz
        /// </summary>
        /// <returns></returns>
        List<Student> GetAllOrderByRank();
        List<Student> GetAllOrderByRank(Expression<Func<Student, bool>> method);
    }
}
