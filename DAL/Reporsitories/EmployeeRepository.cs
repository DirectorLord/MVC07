using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Reporsitories;

public class EmployeeRepository(CompanyDBContext dbConext)
    :BaseRepository<Employee>(dbConext) , IEmployeeRepository
{
    public IEnumerable<Employee> GetAll(string name)
    {
       return _dbSet.Where(e => e.Name == name).ToList();
    }
    public IEnumerable<Employee> GetAll<TResult>
        (Expression<Func<Employee, TResult>> resultSelector, Expression<Func<Employee, bool>>?
        predicate = null)
    {
        if(predicate is null)
            return (IEnumerable<Employee>)_dbSet.Where(x => !x.isDeleted).Select(resultSelector).ToList();
        return (IEnumerable<Employee>)_dbSet.Where(x => !x.isDeleted).Where(predicate)
            .Select(resultSelector).ToList();
    }

    public IQueryable<Employee> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetAllQuery()
    {
        return _dbSet.Where(e => !e.isDeleted);
    }

    public override Employee GetById(int id)
    {
        return _dbSet.Include(e => e.Department).FirstOrDefault(e => e.Id == id)!;
    }
}
