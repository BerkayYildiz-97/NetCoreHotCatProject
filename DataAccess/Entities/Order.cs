using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Order:BaseEntity
    {
        public bool IsActive { get; set; }
        public Table Table { get; set; }
        public int TableId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
