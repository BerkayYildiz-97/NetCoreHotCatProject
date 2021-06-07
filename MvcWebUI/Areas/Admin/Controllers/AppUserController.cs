using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AppUserController(IAppUserService appUserService, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_appUserService.GetAll());
        }
        public IActionResult AddAppUser()
        {
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAppUser(AppUser appUser,int roleid)
        {
            if (ModelState.IsValid)
            {

                var exist = _appUserService.Register(appUser);

                if (exist.Id != 0)
                {
                    _appUserService.UserAddRole(exist, roleid);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Exist"] = $"{appUser.UserName} Kullanıcısı zaten mevcut";
                    return RedirectToAction("Index");

                }

            }
            else
            {

                return View(appUser);
            }
        }
        public IActionResult RemoveAppUser(int id)
        {
            var result = _appUserService.GetById(id);
            _appUserService.Delete(result);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateAppUser(int id)
        {
            var result = _appUserService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateAppUser(AppUser appUser)
        {
            _appUserService.Update(appUser);
            return RedirectToAction("Index");
        }
    }
}
