using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Cashier.Controllers
{
    [Area("Cashier")]
    [Authorize(Roles = "Cashier")]
    public class HomeController : Controller
    {
        private readonly ITableService _tableService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(ITableService tableService,IOrderDetailService orderDetailService,IOrderService orderService,IProductService productService,ICategoryService categoryService )
        {
            _tableService = tableService;
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _categoryService.GetAll(x => x.Status == DataAccess.Entities.Enum.Status.Active);
            ViewBag.Product = _productService.GetAll(x => x.Status == DataAccess.Entities.Enum.Status.Active);
            ViewBag.Table = _tableService.GetAll();
            //var x=_orderService.GetAll().Where(x => x.IsActive == false);
            return View();
        }
        
    }
}
