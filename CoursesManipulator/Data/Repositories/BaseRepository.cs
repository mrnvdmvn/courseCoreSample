using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoursesManipulator.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        readonly CoursesContext context;
        readonly DbSet<TEntity> dbSet;

        protected BaseRepository(CoursesContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }


        public virtual void Add(TEntity entity)
        {
            var dbEntityEntry = context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                dbSet.Add(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            var dbEntityEntry = context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            var dbEntityEntry = context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
        }

        public virtual TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}