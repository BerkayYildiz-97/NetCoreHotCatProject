using DataAccess.Entities;
using DataAccess.Entities.Dtos;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Abstract
{
    public interface ICategoryService:IRepository<Category>
    {
        List<CategoryDetailDto> GetCategoryDetails();
    }
}
