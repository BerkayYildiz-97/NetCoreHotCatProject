using DataAccess.Entities;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Abstract
{
    public interface IOrderService:IRepository<Order>
    {
        //Order AddOrderDetail(OrderDetail orderDetail);

        

    }
}
