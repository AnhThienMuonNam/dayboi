using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Dayboi_Web.Controllers
{
    public class PoolController : Controller
    {
        private readonly IPoolRepository _poolRepository;
        private readonly IPoolCategoryRepository _poolCategoryRepository;

        public PoolController(IPoolRepository poolRepository, IPoolCategoryRepository poolCategoryRepository)
        {
            _poolRepository = poolRepository;
            _poolCategoryRepository = poolCategoryRepository;
        }

        // GET: Pool
        public ActionResult Index(int poolCategoryId)
        {
            var poolCategories = _poolCategoryRepository.GetMany(x => x.IsActive && !x.IsDeleted).Select(x => new PoolCategoryViewModel
                                                                                                        {
                                                                                                            Id = x.Id,
                                                                                                            Name = x.Name,
                                                                                                            Alias = x.Alias
                                                                                                        }).ToList();
            ViewBag.PoolCategories = poolCategories;
            return View(GetPoolsByPoolCategoryId(poolCategoryId));
        }

        private PoolCategoryViewModel GetPoolsByPoolCategoryId(int poolCategoryId)
        {
            var poolCategory = _poolCategoryRepository.GetMany(x => x.Id == poolCategoryId)
                                                        .Include(x => x.Pools)
                                                        .FirstOrDefault();
            var returnPoolCategory = Mapper.Map<PoolCategory, PoolCategoryViewModel>(poolCategory);

            return returnPoolCategory;
        }

        [HttpGet]
        public ActionResult PoolDetail(int poolId)
        {
            return View(GetPoolById(poolId));
        }

        private PoolViewModel GetPoolById(int poolId)
        {
            var pool = _poolRepository.GetMany(x => x.Id == poolId
                                                && x.IsActive
                                                && !x.IsDeleted)
                                                .Include(x => x.PoolTags)
                                                .Include(x => x.PoolCategory)
                                                .FirstOrDefault();

            var returnBlog = Mapper.Map<Pool, PoolViewModel>(pool);
            returnBlog.OtherPools = _poolRepository.GetMany(x => x.Id != poolId
                                                  && !x.IsDeleted && x.IsActive)
                                                  .Select(x => new PoolViewModel()
                                                  {
                                                      Id = x.Id,
                                                      Name = x.Name,
                                                      Alias = x.Alias,
                                                      Image = x.Image,
                                                      Address = x.Address
                                                  }).ToList();
            return returnBlog;
        }
    }
}