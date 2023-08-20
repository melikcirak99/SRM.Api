using SRM.Api.Data.Abstract;
using SRM.Api.Entites;

namespace SRM.Api.Data.Concrete
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        public GradeRepository(Db context) : base(context)
        {
        }
    }
}
