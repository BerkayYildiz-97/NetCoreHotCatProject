using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Table:BaseEntity
    {
        public int Number { get; set; }
        public decimal Account { get; set; }
        public bool IsActive { get; set; }
        public List<Order> Orders { get; set; }
        

    }
}
