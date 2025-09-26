using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Reporsitories;

public interface IEmployeeRepository : IRepository<Employee>
{
    IEnumerable<Employee> GetAll(string name);
    IQueryable<Employee> GetAll();
    IEnumerable<Employee> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector);
}
