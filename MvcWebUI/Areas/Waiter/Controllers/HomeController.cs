using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Controllers;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Waiter.Controllers
{
    [Area("Waiter")]
    [Authorize(Roles = "Waiter")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ICategoryService _categoryService;

        public HomeController(IProductService productService,IOrderService orderService,ICategoryService categoryService)
        {
            _productService = productService;
            _orderService = orderService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var user = AccountController.identityUser;
            var result = _productService.GetAll(x => x.Status == DataAccess.Entities.Enum.Status.Active);
            ViewBag.Categories = _categoryService.GetAll(x => x.Status == DataAccess.Entities.Enum.Status.Active);
            var orders = _orderService.GetAll().Where(x => x.AppUserId == user.Id && x.IsActive==false);
            ViewBag.orders = orders;
            return View(result);
        }
    }
}
