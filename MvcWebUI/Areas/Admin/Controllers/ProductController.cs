using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _categoryService.GetAll(x => x.Status == DataAccess.Entities.Enum.Status.Active);
            return View(_productService.GetAll(x=>x.Status==DataAccess.Entities.Enum.Status.Active));
        }
        public IActionResult AddProduct()
        {
            ViewBag.Categories = _categoryService.GetAll(x => x.Status == DataAccess.Entities.Enum.Status.Active);
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
           
            _productService.Create(product);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveProduct(int id)
        {
            var result = _productService.GetById(id);
            _productService.Delete(result);
            return RedirectToAction("Index");
        }
        public IActionResult GetProduct(Product product)
        {
            var result = _productService.GetById(product.Id);
            return View(result);
        }
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.Categories = _categoryService.GetAll(x => x.Status == DataAccess.Entities.Enum.Status.Active);
            var result = _productService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Index");
        }
    }
}
