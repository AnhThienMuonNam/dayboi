using AutoMapper;
using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    public class PoolCategoryAdminController : Controller
    {
        private readonly IPoolCategoryRepository _poolCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PoolCategoryAdminController(IPoolCategoryRepository poolCategoryRepository,
                                   IUnitOfWork unitOfWork)
        {
            _poolCategoryRepository = poolCategoryRepository;
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            var item = _poolCategoryRepository.GetSingleById(id);
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


        // GET: Admin/PoolCategoryAdmin
        public ActionResult Index()
        {
            var skills = GetSkills();

            return View(skills);
        }

        private IEnumerable<PoolCategoryModel> GetSkills()
        {
            var skills = _poolCategoryRepository.GetMany(x => !x.IsDeleted).ToList();

            var toReturn = Mapper.Map<IEnumerable<PoolCategory>, IEnumerable<PoolCategoryModel>>(skills);
            return toReturn;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreatePoolCategory(PoolCategoryModel model)
        {
            var Skill = Mapper.Map<PoolCategoryModel, PoolCategory>(model);
            if (User.Identity.GetUserId() != null)
            {
                Skill.CreatedBy = User.Identity.GetUserId();
            }
            Skill.CreatedOn = DateTime.Now;
            Skill.IsActive = true;
            Skill.IsDeleted = false;
            var toReturn = _poolCategoryRepository.Add(Skill);
            _unitOfWork.Commit();
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
                var Skill = _poolCategoryRepository.GetMany(x => !x.IsDeleted &&
                                                        x.Id == id)
                                                        .FirstOrDefault();
                if (Skill != null)
                {
                    var toReturn = Mapper.Map<PoolCategory, PoolCategoryModel>(Skill);
                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdatePoolCategory(SkillModel model)
        {
            try
            {
                var entity = _poolCategoryRepository.GetMany(x => x.Id == model.Id && !x.IsDeleted)
                                                .FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Alias = model.Alias;
                    entity.MetaKeyword = model.MetaKeyword;
                    entity.Image = model.Image;
                    entity.IsActive = model.IsActive;

                    if (User.Identity.IsAuthenticated)
                    {
                        entity.UpdatedBy = User.Identity.GetUserId();
                    }
                    entity.UpdatedOn = DateTime.Now;
                    _poolCategoryRepository.Update(entity);
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
    }
}