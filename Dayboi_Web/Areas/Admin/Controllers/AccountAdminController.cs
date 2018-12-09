using AutoMapper;
using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dayboi_Web.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        private readonly IAspNetUsersRepository _aspNetUsersRepository;
        private readonly IApplicationRoleRepository _applicationRoleRepository;
        private readonly ApplicationUserManager _userManager;
        private readonly IIdentityUserRoleRepository _identityUserRoleRepository;

        private readonly IUnitOfWork _unitOfWork;

        public AccountAdminController(IAspNetUsersRepository aspNetUsersRepository,
            IIdentityUserRoleRepository identityUserRoleRepository,
            IApplicationRoleRepository applicationRoleRepository,
            ApplicationUserManager userManager,
                                   IUnitOfWork unitOfWork)
        {
            _aspNetUsersRepository = aspNetUsersRepository;
            _applicationRoleRepository = applicationRoleRepository;
            _identityUserRoleRepository = identityUserRoleRepository;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/AccountAdmin
        public ActionResult Index()
        {
            var skills = GetSkills();

            return View(skills);
        }

        private IEnumerable<AccountModel> GetSkills()
        {
            var skills = _aspNetUsersRepository.GetMany(x => !x.IsDeleted).ToList();

            var toReturn = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<AccountModel>>(skills);
            return toReturn;
        }

        public ActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var user = _aspNetUsersRepository.GetMany(x => !x.IsDeleted &&
                                                        x.Id == id)
                                                        .FirstOrDefault();
                var role = _identityUserRoleRepository.GetMany(x => x.UserId == id).FirstOrDefault();

                if (user != null)
                {
                    ViewBag.Roles = _applicationRoleRepository.GetAll().Select(x => new { Id = x.Id, Name = x.Name }).ToList();
                    var toReturn = Mapper.Map<ApplicationUser, AccountModel>(user);
                    toReturn.RoleId = role.RoleId.ToString();
                    return View(toReturn);
                }
                else
                    return null;
            }
            return null;
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> UpdateAccount(AccountModel model)
        {
            try
            {
                var roles = _applicationRoleRepository.GetAll();

                var entity = _aspNetUsersRepository.GetMany(x => x.Id == model.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.FullName = model.FullName;
                    entity.Address = model.Address;
                    entity.IsActive = model.IsActive;

                    var role = _identityUserRoleRepository.GetMany(x => x.UserId == model.Id).FirstOrDefault();
                    //role.RoleId = Guid.Parse(model.RoleId).ToString();
                    var a1 = roles.Where(x => x.Id == role.RoleId).FirstOrDefault().Name;
                    //_identityUserRoleRepository.Update(role);
                    await _userManager.RemoveFromRoleAsync(model.Id, roles.Where(x => x.Id == role.RoleId).FirstOrDefault().Name);
                    await _userManager.AddToRoleAsync(model.Id, roles.Where(x => x.Id == model.RoleId).FirstOrDefault().Name);
                    _aspNetUsersRepository.Update(entity);
                    _unitOfWork.Commit();
                }
                return Json(new
                {
                    IsSuccess = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    IsSuccess = false
                });
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("/");
        }
    }
}