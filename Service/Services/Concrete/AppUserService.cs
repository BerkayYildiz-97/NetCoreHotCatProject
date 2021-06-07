using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Repositories;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class AppUserService:Repository<AppUser>,IAppUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserService(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) :base(context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public AppUser Register(AppUser register)
        {
            var existEmail = _userManager.FindByEmailAsync(register.Email).Result;
            var existUserName = _userManager.FindByNameAsync(register.UserName).Result;
            if (existEmail != null || existUserName != null)
            {
                return register;
            }
            else
            {
                var createdBy = string.Empty;
                if (_signInManager.Context.User.Identity.Name != null)
                {
                    createdBy = _signInManager.Context.User.Identity.Name;
                }
                else
                {
                    createdBy = register.UserName;
                }
                AppUser user = new AppUser
                {
                    UserName = register.UserName,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Email = register.Email,
                    PhoneNumber = register.PhoneNumber,
                    
                };

                var result = _userManager.CreateAsync(user, register.Password).Result;
                _context.SaveChanges();

                return user;

            }
        }

        public void UserAddRole(AppUser user, int roleid)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == roleid);

            var result = _userManager.AddToRoleAsync(user, role.Name).Result;

            _context.SaveChanges();
        }
    }
}
