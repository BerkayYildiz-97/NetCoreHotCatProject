using DataAccess.Context;
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
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ApplicationDbContext _context;
        private readonly IProductService _productService;
        private readonly IOrderDetailService _orderDetailService;

        public HomeController(IOrderService orderService, ApplicationDbContext context,IProductService productService,IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _context = context;
            _productService = productService;
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index()
        {
            ViewBag.Product = _productService.GetAll(x => x.Status == DataAccess.Entities.Enum.Status.Active);
            return View();
        }

        //public IActionResult OrderByDescending()
        //{
        //    var orderDetails = _orderDetailService.GetAll();

        //    var soldProduct = orderDetails.OrderByDescending(x => x.Quantity);
        //    return View(soldProduct);
        //}
    }
}
