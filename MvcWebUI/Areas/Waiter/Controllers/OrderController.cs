using Common;
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

namespace MvcWebUI.Areas.Waiter.Controllers
{
    [Area("Waiter")]
    [Authorize(Roles = "Waiter")]

    public class OrderController : Controller
    {
       
        private readonly IOrderService _orderService;
        private readonly ITableService _tableService;
        private readonly IAppUserService _appUserService;
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ApplicationDbContext _context;

        public OrderController(IOrderService orderService,ITableService tableService,IAppUserService appUserService,IProductService productService,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IOrderDetailService orderDetailService,ApplicationDbContext context)
        {
            _orderService = orderService;
            _tableService = tableService;
            _appUserService = appUserService;
            _productService = productService;
            _userManager = userManager;
            _signInManager = signInManager;
            _orderDetailService = orderDetailService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateOrder()
        {
            
            ViewBag.Table = _tableService.GetAll().Where(x=>x.IsActive==false);
       
           return View();
        }

        public IActionResult Create(Order order)
        {
            order.AppUser = _signInManager.UserManager.FindByNameAsync(User.Identity.Name).Result;
            order.AppUserId = AccountController.identityUser.Id;
            order.Table = _tableService.GetById(order.TableId);
            order.Table.IsActive = true;
            

            if (order.Id == 0)
            {
                _orderService.Create(order);
                
                _orderService.Update(order);
            }
            else
            {
                var orderList = _orderDetailService.GetAll().Where(x => x.OrderId == order.Id).ToList();

                TempData["OrderList"] = orderList;
            }

            ViewBag.Table = _tableService.GetById(order.TableId);
            ViewBag.Products = _productService.GetAll(x => x.Status == DataAccess.Entities.Enum.Status.Active);
            ViewBag.OrderId = order.Id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail orderDetail)
        {
            try
            {

                //var order = _orderService.AddOrderDetail(orderDetail);

                //return RedirectToAction("Create", order);


                var orders = _orderDetailService.GetAll().Where(x => x.OrderId == orderDetail.OrderId);
                var detail = orders.FirstOrDefault(x => x.ProductId == orderDetail.ProductId);
                var product = _productService.GetById(orderDetail.ProductId);

                var order = _orderService.GetById(orderDetail.OrderId);
                if (orders != null)
                {
                    if (detail == null)
                    {
                        orderDetail.UnitPrice = product.UnitPrice;
                        orderDetail.Id = 0;
                        _orderDetailService.Create(orderDetail);

                        product.UnitsInStock -= orderDetail.Quantity;
                        _productService.Update(product);

                        if (product.UnitsInStock <= 50)
                        {
                            MailSender.SendMail(product);
                        }

                        return RedirectToAction("Create", order);
                    }
                    else
                    {
                        var qua = orderDetail.Quantity;
                        detail.Quantity += qua;
                        _orderDetailService.Update(detail);

                        product.UnitsInStock -= orderDetail.Quantity;
                        _productService.Update(product);

                        if (product.UnitsInStock <= 50)
                        {
                            MailSender.SendMail(product);
                        }

                        return RedirectToAction("Create", order);
                    }
                }
                else
                {
                    orderDetail.UnitPrice = product.UnitPrice;
                    _orderDetailService.Create(orderDetail);

                    product.UnitsInStock -= orderDetail.Quantity;
                    _productService.Update(product);

                    if (product.UnitsInStock <= 50)
                    {
                        MailSender.SendMail(product);
                    }

                    return RedirectToAction("Create", order);
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
