using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IEnrollmentCourseRepository : IRepository<EnrollmentCourse>
    {
    }

    public class EnrollmentCourseRepository : RepositoryBase<EnrollmentCourse>, IEnrollmentCourseRepository
    {
        public EnrollmentCourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
