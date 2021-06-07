using DataAccess.Entities;
using Service.Repositories;
using Service.ViewModels.ApiVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Abstract
{
    public interface IProductService:IRepository<Product>
    {
        List<ProductVM> GetProductsApi();
        //void SendEmail(Product product);
    }
}
