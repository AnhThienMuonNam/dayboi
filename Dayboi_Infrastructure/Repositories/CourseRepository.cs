using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;

namespace Dayboi_Infrastructure.Repositories
{

    public interface ICourseRepository : IRepository<Course>
    {
    }

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICourseTagRepository : IRepository<CourseTag>
    {
    }

    public class CourseTagRepository : RepositoryBase<CourseTag>, ICourseTagRepository
    {
        public CourseTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
