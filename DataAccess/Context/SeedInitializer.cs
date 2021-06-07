using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public static class SeedInitializer
    {
        public static void SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager/*, ApplicationDbContext context*/)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            //SeedUse(context);
        }

        private static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                AppUser Admin = new AppUser();
                Admin.UserName = "Admin";
                Admin.Email = "admin@admin.com";
                Admin.FirstName = "Admin";
                Admin.LastName = "Admin";
                


                AppUser Cashier = new AppUser();
                Cashier.UserName = "Cashier";
                Cashier.Email = "denemeproje307@gmail.com";
                Cashier.FirstName = "Cashier";
                Cashier.LastName = "Cashier";



                AppUser Waiter = new AppUser();
                Waiter.UserName = "Waiter";
                Waiter.Email = "Waiter@Waiter.com";
                Waiter.FirstName = "Waiter";
                Waiter.LastName = "Waiter";


                AppUser Waiter2 = new AppUser();
                Waiter2.UserName = "Waiter2";
                Waiter2.Email = "Waiter2@Waiter.com";
                Waiter2.FirstName = "Waiter2";
                Waiter2.LastName = "Waiter2";

                AppUser Buyer = new AppUser();
                Buyer.Email = "denemeproje307@gmail.com";


                var resultAdmin = userManager.CreateAsync(Admin, "Test123++").Result;
                if (resultAdmin.Succeeded)
                {
                    userManager.AddToRoleAsync(Admin, "Admin").Wait();
                }
                else
                {
                    foreach (var item in resultAdmin.Errors)
                    {

                    }
                }

                var resultKasiyer = userManager.CreateAsync(Cashier, "Test123++").Result;
                if (resultKasiyer.Succeeded)
                {
                    userManager.AddToRoleAsync(Cashier, "Cashier").Wait();
                }
                else
                {
                    foreach (var item in resultKasiyer.Errors)
                    {

                    }
                }



                var resultWaiter = userManager.CreateAsync(Waiter, "Test123++").Result;
                if (resultWaiter.Succeeded)
                {
                    userManager.AddToRoleAsync(Waiter, "Waiter").Wait();
                }
                else
                {
                    foreach (var item in resultWaiter.Errors)
                    {

                    }
                }


                var resultWaiter2 = userManager.CreateAsync(Waiter2, "Test123++").Result;
                if (resultWaiter2.Succeeded)
                {
                    userManager.AddToRoleAsync(Waiter2, "Waiter").Wait();
                }
                else
                {
                    foreach (var item in resultWaiter2.Errors)
                    {

                    }
                }



            }
        }

        private static void SeedRoles(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Admin";
                var roleResult = roleManager.CreateAsync(role).Result;
                if (roleResult.Succeeded)
                {

                }

            }

            if (!roleManager.RoleExistsAsync("Cashier").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Cashier";
                var roleResult = roleManager.CreateAsync(role).Result;
                if (roleResult.Succeeded)
                {

                }

            }



            if (!roleManager.RoleExistsAsync("Waiter").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Waiter";
                var roleResult = roleManager.CreateAsync(role).Result;
                if (roleResult.Succeeded)
                {

                }

            }

        }


       
    }
}
