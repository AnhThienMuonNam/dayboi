using AutoMapper;
using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    public class PoolAdminController : Controller
    {
        private readonly IPoolRepository _poolRepository;
        private readonly IPoolTagRepository _poolTagRepository;
        private readonly IPoolCategoryRepository _poolCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PoolAdminController(IPoolRepository poolRepository,
                                   IPoolTagRepository poolTagRepository,
                                   IPoolCategoryRepository poolCategoryRepository,
                                   IUnitOfWork unitOfWork)
        {
            _poolRepository = poolRepository;
            _poolTagRepository = poolTagRepository;
            _poolCategoryRepository = poolCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var item = _poolRepository.GetSingleById(id);
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


        // GET: Admin/PoolAdmin
        public ActionResult Index()
        {
            var courses = GetPools();

            return View(courses);
        }

        private IEnumerable<PoolModel> GetPools()
        {
            var courses = _poolRepository.GetMany(x => !x.IsDeleted)
                                        .Include(x => x.PoolCategory)
                                        .ToList();

            var toReturn = Mapper.Map<IEnumerable<Pool>, IEnumerable<PoolModel>>(courses);
            return toReturn;
        }


        public ActionResult Create()
        {
            var poolCategories = _poolCategoryRepository.GetMany(x => !x.IsDeleted && x.IsActive)
                                                        .Select(x => new { Id = x.Id, Name = x.Name })
                                                        .ToList();
            ViewBag.PoolCategories = poolCategories;
            return View();
        }

        [HttpPost]
        public JsonResult CreatePool(PoolModel model)
        {
            var pool = Mapper.Map<PoolModel, Pool>(model);
            AddPoolTag(pool, model.Tags);
            if (User.Identity.GetUserId() != null)
            {
                pool.CreatedBy = User.Identity.GetUserId();
            }
            pool.CreatedOn = DateTime.Now;
            pool.IsDeleted = false;
            var toReturn = _poolRepository.Add(pool);
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
                var pool = _poolRepository.GetMany(x => !x.IsDeleted &&
                                                        x.Id == id)
                                                        .Include(x => x.PoolTags)
                                                        .FirstOrDefault();
                if (pool != null)
                {
                    var poolCategories = _poolCategoryRepository.GetMany(x => !x.IsDeleted)
                                                       .Select(x => new { Id = x.Id, Name = x.Name })
                                                       .ToList();
                    ViewBag.PoolCategories = poolCategories;

                    var toReturn = Mapper.Map<Pool, PoolModel>(pool);
                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdatePool(PoolModel model)
        {
            try
            {
                var entity = _poolRepository.GetMany(x => x.Id == model.Id && !x.IsDeleted)
                                                .Include(x => x.PoolTags)
                                                .FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Alias = model.Alias;
                    entity.MetaKeyword = model.MetaKeyword;
                    entity.Address = model.Address;
                    entity.Image = model.Image;
                    entity.IsActive = model.IsActive;
                    entity.Content = model.Content;
                    entity.PoolCategoryId = model.PoolCategoryId;
                    entity.OpeningHour = model.OpeningHour;
                    entity.OpeningDay = model.OpeningDay;
                    entity.ClosedHour = model.ClosedHour;
                    entity.Fare = model.Fare;

                    AddPoolTag(entity, model.Tags);
                    if (User.Identity.IsAuthenticated)
                    {
                        entity.UpdatedBy = User.Identity.GetUserId();
                    }
                    _poolRepository.Update(entity);
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

        private void AddPoolTag(Pool pool, List<string> tags)
        {
            if (pool.Id > 0)
            {
                _poolTagRepository.DeleteMulti(x => x.PoolId == pool.Id);
            }
            else
            {
                pool.PoolTags = new List<PoolTag>();
            }
            if (tags.Count > 0)
            {
                foreach (var newTag in tags)
                {
                    var tag = new PoolTag();
                    tag.Tag = newTag;
                    pool.PoolTags.Add(tag);
                }
            }
        }
    }
}