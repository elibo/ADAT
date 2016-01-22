using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicosORM.DAL
{
   public  class Repository<TEntity> where TEntity : class
    {
        protected CentroMedicoEntities context = new CentroMedicoEntities();
        DbSet<TEntity> dbSet;

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();

        }

        public void Create(TEntity entity)
        {
            try
            {
                dbSet = context.Set<TEntity>();
                dbSet.Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public List<TEntity> getAll()
        {
            return (List<TEntity>)context.Set<TEntity>().ToList();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predictate) {
            dbSet = context.Set<TEntity>();
            return dbSet.FirstOrDefault(predictate);
        }






    }
}
