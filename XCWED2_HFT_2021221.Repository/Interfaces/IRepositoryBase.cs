using System.Linq;

namespace XCWED2_HFT_2021221.Repository.Interfaces
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

