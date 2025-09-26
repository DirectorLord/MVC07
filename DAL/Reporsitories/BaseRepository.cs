using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Reporsitories;

public class BaseRepository<TEntity>(CompanyDBContext dbContext) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public int Add(TEntity TEntity)
    {
        _dbSet.Add(TEntity);
        return dbContext.SaveChanges();
    }
    public int Update(TEntity TEntity)
    {
        _dbSet.Update(TEntity);
        return dbContext.SaveChanges();
    }
    public int Delete(TEntity TEntity)
    {
        _dbSet.Remove(TEntity);
        return dbContext.SaveChanges();
    }
    public IEnumerable<TEntity> GetAllQuery(bool trackChanges = false)
    {
       return trackChanges ? _dbSet
            .Where(x => !x.isDeleted).ToList(): _dbSet.AsNoTracking().Where(x => !x.isDeleted).ToList();
    }
    public TEntity GetById(int id)
    {
        return _dbSet.Find(id);
    }
}
