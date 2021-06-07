using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        

    }
}
