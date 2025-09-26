using DAL.Entities;

namespace DAL.Reporsitories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IEnumerable<TEntity> GetAllQuery(bool trackChanges = false);
    TEntity GetById(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
