using AutoMapper;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.ViewModels;
using System.Collections.Generic;
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
            return View(GetPoolsByPoolCategoryId(poolCategoryId));
        }

        private IEnumerable<PoolViewModel> GetPoolsByPoolCategoryId(int poolCategoryId)
        {
            var blogs = _poolRepository.GetMany(x => x.IsActive && x.PoolCategoryId == poolCategoryId &&
                                                !x.IsDeleted)
                                                .Select(x => new PoolViewModel
                                                {
                                                    Id = x.Id,
                                                    Name = x.Name,
                                                    Image = x.Image,
                                                    Alias = x.Alias,
                                                    Address = x.Address,
                                                    CreatedOn = x.CreatedOn
                                                }).ToList();
            return blogs;
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