using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Reporsitories;

public class BaseRepository<TEntity>(CompanyDBContext dbContext) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public virtual void Add(TEntity TEntity)
    {
        _dbSet.Add(TEntity);
    }
    public virtual void Update(TEntity TEntity)
    {
        _dbSet.Update(TEntity);
    }
    public virtual void Delete(TEntity TEntity)
    {
        _dbSet.Remove(TEntity);
    }
    public IEnumerable<TEntity> GetAllQuery(bool trackChanges = false)
    {
       return trackChanges ? _dbSet
            .Where(x => !x.isDeleted).ToList(): _dbSet.AsNoTracking().Where(x => !x.isDeleted).ToList();
    }
    public virtual TEntity GetById(int id)
    {
        return _dbSet.Find(id);
    }
}
