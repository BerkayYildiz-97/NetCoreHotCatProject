using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Maps
{
    //public class OrderTableMap : IEntityTypeConfiguration<Order>
    //{
    //    public void Configure(EntityTypeBuilder<Order> builder)
    //    {
    //        builder.Ignore(x => x.Id);
    //        builder.HasKey(x => new { x.ProductId, x.TableId });
    //        builder.HasOne(x => x.Product).WithMany(x => x.Orders).HasForeignKey(x => x.ProductId);
    //        builder.HasOne(x => x.Table).WithMany(x => x.Orders).HasForeignKey(x => x.TableId);
    //    }
    //}
}
