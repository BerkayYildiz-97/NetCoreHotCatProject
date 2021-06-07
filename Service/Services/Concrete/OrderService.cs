using Common;
using DataAccess.Context;
using DataAccess.Entities;
using Service.Repositories;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class OrderService:Repository<Order>,IOrderService
    {
        
        public OrderService(ApplicationDbContext context) :base(context)
        {
           
        }


        //constructor da service leri kullandığım anda program.cs de hata alıyorum.Controller daki kodları iş katmanına taşıyamadım

        //public Order AddOrderDetail(OrderDetail orderDetail)
        //{
        //    try
        //    {

        //        var orders = _orderDetailService.GetAll().Where(x => x.OrderId == orderDetail.OrderId);
        //        var detail = orders.FirstOrDefault(x => x.ProductId == orderDetail.ProductId);
        //        var product = _productService.GetById(orderDetail.ProductId);

        //        var order = _orderService.GetById(orderDetail.OrderId);
        //        if (orders != null)
        //        {
        //            if (detail == null)
        //            {
        //                orderDetail.UnitPrice = product.UnitPrice;
        //                orderDetail.Id = 0;
        //                _orderDetailService.Create(orderDetail);

        //                product.UnitsInStock -= orderDetail.Quantity;
        //                _productService.Update(product);

        //                if (product.UnitsInStock <= 50)
        //                {
        //                    MailSender.SendMail(product);
        //                }

        //                return order;
        //            }
        //            else
        //            {
        //                var qua = orderDetail.Quantity;
        //                detail.Quantity += qua;
        //                _orderDetailService.Update(detail);

        //                product.UnitsInStock -= orderDetail.Quantity;
        //                _productService.Update(product);

        //                if (product.UnitsInStock <= 50)
        //                {
        //                    MailSender.SendMail(product);
        //                }

        //                return order;
        //            }
        //        }
        //        else
        //        {
        //            orderDetail.UnitPrice = product.UnitPrice;
        //            _orderDetailService.Create(orderDetail);

        //            product.UnitsInStock -= orderDetail.Quantity;
        //            _productService.Update(product);

        //            if (product.UnitsInStock <= 50)
        //            {
        //                MailSender.SendMail(product);
        //            }

        //            return order;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

       
    }
}
