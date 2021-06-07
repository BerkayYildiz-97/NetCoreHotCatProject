using Common;
using DataAccess.Context;
using DataAccess.Entities;
using Service.Repositories;
using Service.Services.Abstract;
using Service.ViewModels.ApiVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class ProductService:Repository<Product>,IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public override void Delete(Product entity)
        {
            entity.Status = DataAccess.Entities.Enum.Status.Deleted;
            _context.Update(entity);
            _context.SaveChanges();
        }

        //public void SendEmail(Product product)
        //{
        //    var products = _context.Products.ToList();
        //    foreach (Product product1 in products)
        //    {
        //        if (product.Id==product1.Id && product.UnitsInStock<=50)
        //        {
        //            MailSender.SendMail();
        //        }
        //    }
        //}


        public List<ProductVM> GetProductsApi()
        {
            var q = from p in _context.Products
                        select new ProductVM
                        {
                            ProductName = p.Name,
                            UnitPrice = p.UnitPrice,
                            UnıtsInStock = p.UnitsInStock
                        };

            return q.ToList();
        }
    }
}
