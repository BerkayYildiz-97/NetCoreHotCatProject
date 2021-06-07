using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
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
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        public IActionResult Index()
        {
            return View(_branchService.GetAll());
        }
        public IActionResult AddBranch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBranch(Branch branch)
        {
            _branchService.Create(branch);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveBranch(int id)
        {
            var result = _branchService.GetById(id);
            _branchService.Delete(result);
            return RedirectToAction("Index");
        }
        public IActionResult GetBranch(Branch branch)
        {
            var result = _branchService.GetById(branch.Id);
            return View(result);
        }
        public IActionResult UpdateBranch(int id)
        {
            var result = _branchService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateBranch(Branch branch)
        {
            _branchService.Update(branch);
            return RedirectToAction("Index");
        }

    }
}
