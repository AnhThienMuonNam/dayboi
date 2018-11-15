using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpGet]
        public ActionResult SkillDetail(int skillId)
        {
            return View(GetSkillById(skillId));
        }

        private SkillViewModel GetSkillById(int skillId)
        {
            var skill = _skillRepository.GetMany(x => x.Id == skillId && !x.IsDeleted)
                                                .Include(x => x.SkillTags)
                                                .FirstOrDefault();

            var returnSkill = Mapper.Map<Skill, SkillViewModel>(skill);
            returnSkill.OtherSkills = _skillRepository.GetMany(x => x.Id != skillId
                                                 && !x.IsDeleted && x.IsActive)
                                                 .Select(x => new SkillViewModel()
                                                 {
                                                     Id = x.Id,
                                                     Name = x.Name,
                                                     Alias = x.Alias,
                                                     Image = x.Image,
                                                     Description = x.Description
                                                 }).ToList();
            return returnSkill;
        }
    }
}