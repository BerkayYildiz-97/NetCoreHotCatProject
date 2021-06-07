using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public IActionResult Index()
        {
            return View(_companyService.GetAll());
        }
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCompany(Company company)
        {
            _companyService.Create(company);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveCompany(int id)
        {
            var result = _companyService.GetById(id);
            _companyService.Delete(result);
            return RedirectToAction("Index");
        }
        public IActionResult GetCompany(Company company)
        {
            var result = _companyService.GetById(company.Id);
            return View(result);
        }
        public IActionResult UpdateCompany(int id)
        {
            var result = _companyService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateCompany(Company company)
        {
            _companyService.Update(company);
            return RedirectToAction("Index");
        }
    }
}
