using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName="Yiyecek" },
                new Category { Id = 2, CategoryName="İçecek" },
                new Category { Id = 3, CategoryName="Hamburger",ParentId=1 },
                new Category { Id = 4, CategoryName="Pizza",ParentId=1 },
                new Category { Id = 5, CategoryName="Soğuk İçecek",ParentId=2 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1,Name="Whooper", UnitPrice=25, UnitsInStock=100, CategoryId=3 },
                new Product { Id = 2, Name = "Margarita", UnitPrice = 30, UnitsInStock = 100, CategoryId = 4 },
                new Product { Id = 3, Name = "Kola", UnitPrice = 4, UnitsInStock = 200, CategoryId = 5 }
                );

            modelBuilder.Entity<Table>().HasData(
                new Table { Id = 1, Number=1 },
                new Table { Id = 2, Number=2 },
                new Table { Id = 3, Number=3},
                new Table { Id = 4, Number = 4 }
                );


        }
    }
}
