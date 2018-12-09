using AutoMapper;
using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Service.Admin;
using Dayboi_Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class SkillAdminController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        private readonly ISkillAdminService _skillAdminService;
        private readonly ISkillTagRepository _skillTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SkillAdminController(ISkillRepository skillRepository,
                                   ISkillAdminService skillAdminService,
                                   ISkillTagRepository skillTagRepository,
                                   IUnitOfWork unitOfWork)
        {
            _skillRepository = skillRepository;
            _skillTagRepository = skillTagRepository;
            _skillAdminService = skillAdminService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var item = _skillRepository.GetSingleById(id);
            var toReturn = false;
            if (item != null)
            {
                item.IsDeleted = true;

                if (User.Identity.IsAuthenticated)
                {
                    item.UpdatedBy = User.Identity.GetUserId();
                }

                _unitOfWork.Commit();
                toReturn = true;

            }
            return Json(new
            {
                IsSuccess = toReturn
            });
        }

        public ActionResult Index()
        {
            var skills = GetSkills();
            return View(skills);
        }

        private IEnumerable<SkillModel> GetSkills()
        {
            var skills = _skillRepository.GetMany(x => !x.IsDeleted).ToList();

            var toReturn = Mapper.Map<IEnumerable<Skill>, IEnumerable<SkillModel>>(skills);
            return toReturn;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateSkill(SkillModel model)
        {
            var Skill = Mapper.Map<SkillModel, Skill>(model);
            AddSkillTag(Skill, model.Tags);
            if (User.Identity.GetUserId() != null)
            {
                Skill.CreatedBy = User.Identity.GetUserId();
            }
            var toReturn = _skillAdminService.Create(Skill);
            return Json(new
            {
                IsSuccess = true,
                Data = toReturn
            });
        }

        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var Skill = _skillRepository.GetMany(x => !x.IsDeleted &&
                                                        x.Id == id)
                                                        .Include(x => x.SkillTags)
                                                        .FirstOrDefault();
                if (Skill != null)
                {
                    var toReturn = Mapper.Map<Skill, SkillModel>(Skill);
                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdateSkill(SkillModel model)
        {
            try
            {
                var entity = _skillRepository.GetMany(x => x.Id == model.Id && !x.IsDeleted)
                                                .Include(x => x.SkillTags)
                                                .FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Alias = model.Alias;
                    entity.MetaKeyword = model.MetaKeyword;
                    entity.Description = model.Description;
                    entity.Image = model.Image;
                    entity.IsActive = model.IsActive;
                    entity.Content = model.Content;

                    AddSkillTag(entity, model.Tags);
                    if (User.Identity.IsAuthenticated)
                    {
                        entity.UpdatedBy = User.Identity.GetUserId();
                    }
                    _skillRepository.Update(entity);
                    _unitOfWork.Commit();
                }
                return Json(new
                {
                    IsSuccess = true
                });
            }
            catch
            {
                return Json(new
                {
                    IsSuccess = false
                });
            }
        }

        private void AddSkillTag(Skill skill, List<string> tags)
        {
            if (skill.Id > 0)
            {
                _skillTagRepository.DeleteMulti(x => x.SkillId == skill.Id);
            }
            else
            {
                skill.SkillTags = new List<SkillTag>();
            }
            if (tags.Count > 0)
            {
                foreach (var newTag in tags)
                {
                    var tag = new SkillTag();
                    tag.Tag = newTag;
                    skill.SkillTags.Add(tag);
                }
            }
        }
    }
}