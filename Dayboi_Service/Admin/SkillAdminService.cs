using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using System;

namespace Dayboi_Service.Admin
{
    public interface ISkillAdminService
    {
        Skill Create(Skill entity);
    }
    public class SkillAdminService : ISkillAdminService
    {
        private readonly ISkillRepository _skillRepository;

        private readonly IUnitOfWork _unitOfWork;

        public SkillAdminService(ISkillRepository skillRepository,
                                    IUnitOfWork unitOfWork)
        {
            _skillRepository = skillRepository;
            _unitOfWork = unitOfWork;
        }

        public Skill Create(Skill entity)
        {
            try
            {
                entity.CreatedOn = DateTime.Now;
                entity.IsDeleted = false;
                _skillRepository.Add(entity);
                _unitOfWork.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
