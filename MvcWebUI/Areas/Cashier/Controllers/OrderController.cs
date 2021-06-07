using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Controllers;
using Service.Services.Abstract;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Cashier.Controllers
{
    [Area("Cashier")]
    [Authorize(Roles = "Cashier")]
    public class OrderController : Controller
    {
        
        private readonly IOrderService _orderService;
        private readonly IAppUserService _appUserService;
        private readonly IProductService _productService;
        private readonly ITableService _tableService;
        private readonly ApplicationDbContext _context;
        private readonly IOrderDetailService _orderDetailService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public OrderController(IOrderService orderService,IAppUserService appUserService,IProductService productService,ITableService tableService,ApplicationDbContext context,IOrderDetailService orderDetailService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _orderService = orderService;
            _appUserService = appUserService;
            _productService = productService;
            _tableService = tableService;
            _context = context;
            _orderDetailService = orderDetailService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderDone(int masaId)
        {
           var t = _tableService.GetById(masaId);
            t.IsActive = false;
            _tableService.Update(t);
            decimal total = 0;


            var query = from o in _context.Orders
                        join od in _context.OrderDetails on o.Id equals od.OrderId
                        join p in _context.Products on od.ProductId equals p.Id
                        where o.TableId == masaId
                        where o.IsActive == false
                        select new OrderDetailVM
                        {
                            OrderDetailId=od.Id,
                            OrderId=o.Id,
                            ProductName=p.Name,
                            Quantity=od.Quantity,
                            UnitPrice=p.UnitPrice,
                            IsActive=o.IsActive
                        };

            var order = query.Where(x=>x.IsActive==false).ToList();
            

            foreach (var item in order)
            {
                total += (decimal)(item.UnitPrice * item.Quantity);
            }
            TempData["total"] = total;
            

            return View(order);
        }

       
        public IActionResult Order(int id)
        {

            var order = _orderService.GetById(id);
            
            
            order.IsActive = true;
            _orderService.Update(order);

            //var product = _productService.GetById(orderDetail.ProductId);
            //product.UnitsInStock -= orderDetail.Quantity;
            //_productService.Update(product);

            return RedirectToAction("Index","Home");

        }
    }
}
