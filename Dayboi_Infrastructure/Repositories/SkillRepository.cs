using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;

namespace Dayboi_Infrastructure.Repositories
{
    public interface ISkillRepository : IRepository<Skill>
    {
    }

    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        public SkillRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ISkillTagRepository : IRepository<SkillTag>
    {
    }

    public class SkillTagRepository : RepositoryBase<SkillTag>, ISkillTagRepository
    {
        public SkillTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
