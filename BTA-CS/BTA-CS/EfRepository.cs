using BTA_CS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BTA_CS
{
    public class EfRepository<T>
        where T : class, IEntity, new()
    {
        private DbContext context;

        public EfRepository(DbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                context.Set<T>().Remove(entity);
            }

            context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return context.Set<T>().SingleOrDefault(a => a.id == id);
        }

        public int Insert(T entity)
        {
            context.Set<T>().Add(entity);

            context.SaveChanges();

            return entity.id;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}