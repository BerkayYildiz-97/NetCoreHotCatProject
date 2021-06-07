using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class Repository<T> : IRepository<T> where T : class,new()
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public void Create(T entity)
        {
            if (entity != null)
            {
                entities.Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                
                entities.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> exp = null)
        {

            //return entities.ToList();
            return exp == null
                ? entities.ToList()
                : entities.Where(exp).ToList();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public void Update(T entity)
        {
            try
            {
                entities.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
    }
}
