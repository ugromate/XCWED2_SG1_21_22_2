using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.Repository.DbContexts;
using XCWED2_SG1_21_22_2.Repository.Interfaces;

namespace XCWED2_SG1_21_22_2.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        protected XCWED2_SG1_21_22_2DbContext Context;

        protected RepositoryBase(XCWED2_SG1_21_22_2DbContext context)
        {
            Context = context;
        }

        public TEntity Create(TEntity entity)
        {
            var result = Context.Add(entity);
            Context.SaveChanges();
            return result.Entity;
        }
        public abstract TEntity Read(TKey id);

        public IQueryable<TEntity> ReadAll()
        {
            return Context.Set<TEntity>();

        }
        public TEntity Update(TEntity entity)
        {
            var result = Context.Update(entity);
            Context.SaveChanges();
            return result.Entity;
        }

        public void Delete(TKey id)
        {
            Context.Remove(Read(id));
            Context.SaveChanges();
        }

    }
}
