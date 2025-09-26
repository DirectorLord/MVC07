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
    public IEnumerable<Employee> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector)
    {
       return _dbSet.Where(e =>!e.isDeleted).Select(resultSelector).ToList();
    }
    public IQueryable<Employee> GetAllQuery()
    {
        return _dbSet.Where( e => !e.isDeleted);
    }
}
