using Microsoft.EntityFrameworkCore;
using SRM.Api.Data.Abstract;
using SRM.Api.Entites;
using System.Linq.Expressions;

namespace SRM.Api.Data.Concrete
{
    public class StudentLessonRepository : Repository<StudentLesson>, IStudentLessonRepository
    {
        public StudentLessonRepository(Db context) : base(context)
        {
        }

    }
}
