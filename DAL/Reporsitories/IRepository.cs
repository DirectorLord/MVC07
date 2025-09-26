using DAL.Entities;

namespace DAL.Reporsitories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IEnumerable<TEntity> GetAllQuery(bool trackChanges = false);
    TEntity GetById(int id);
    int Add(TEntity entity);
    int Update(TEntity entity);
    int Delete(TEntity entity);
}
