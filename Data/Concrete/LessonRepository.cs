using SRM.Api.Data.Abstract;
using SRM.Api.Entites;

namespace SRM.Api.Data.Concrete
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(Db context) : base(context)
        {
        }
    }
}
