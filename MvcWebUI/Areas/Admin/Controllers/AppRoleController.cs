using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //kullanım dışı,admin panelde gerek kalmadı kullanıcı eklerken rol seçebiliyoruz.
    public class AppRoleController : Controller
    {
       
        private readonly IRepository<AppRole> _approleService;

        public AppRoleController(IRepository<AppRole> approleService)
        {
            _approleService = approleService;
        }
        public IActionResult Index()
        {
            return View(_approleService.GetAll());
        }
        public IActionResult AddAppRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAppRole(AppRole appRole)
        {
            _approleService.Create(appRole);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveAppRole(int id)
        {
            var result = _approleService.GetById(id);
            _approleService.Delete(result);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateAppRole(int id)
        {
            var result = _approleService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateAppRole(AppRole appRole)
        {
            _approleService.Update(appRole);
            return RedirectToAction("Index");
        }
    }
}
