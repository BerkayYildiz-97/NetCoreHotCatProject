using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ApplicationDbContext context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email

                };
                var result = await userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return View(registerVM);
                }

            }
            else
            {
                return View(registerVM);
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        
        public static AppUser identityUser = new AppUser();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var users = userManager.FindByNameAsync(loginVM.UserName).Result;

            if (users != null)
            {
                //identityName = users;
                var result = signInManager.PasswordSignInAsync(users, loginVM.Password, loginVM.IsPersistant, false).Result;
                if (result.Succeeded)
                {
                    var query = from user in context.Users
                                join userRole in context.UserRoles on user.Id equals userRole.UserId
                                join role in context.Roles on userRole.RoleId equals role.Id
                                select new { user.UserName, role.Name };
                    var q = query.Where(x => x.UserName == users.UserName).FirstOrDefault();
                    //identityUserName = q.UserName;
                    identityUser = users;
                    return Redirect($"/{q.Name}/Home/Index");
                }
                return View();
            }
            return View();
        }

        public async Task<IActionResult> LogOut(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");

        }

    }
}
