using System.Linq;

namespace XCWED2_SG1_21_22_2.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        IQueryable<TEntity> ReadAll();

        TEntity Read(TKey id);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TKey id);
    }
}

