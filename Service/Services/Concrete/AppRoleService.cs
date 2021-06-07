using DataAccess.Context;
using DataAccess.Entities;
using Service.Repositories;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class AppRoleService:Repository<AppRole>,IAppRoleService
    {
        public AppRoleService(ApplicationDbContext context):base(context)
        {

        }
    }
}
