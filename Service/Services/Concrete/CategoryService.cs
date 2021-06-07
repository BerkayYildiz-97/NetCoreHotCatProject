using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Entities.Dtos;
using Service.Repositories;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class CategoryService : Repository<Category>, ICategoryService
    {
        ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public override void Delete(Category entity)
        {
            entity.Status = DataAccess.Entities.Enum.Status.Deleted;
            _context.Update(entity);
            _context.SaveChanges();
        }

        public List<CategoryDetailDto> GetCategoryDetails()
        {
                var result = _context.Categories.Select(x => new CategoryDetailDto
                {
                    CategoryId = x.Id,
                    CategoryName = x.CategoryName,
                    ParentId = x.ParentId,
                    Children = x.Children
                }).ToList();

                return result;
        }

    }
}
