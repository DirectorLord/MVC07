global using AutoMapper;
global using BLL.DataTransferObject.Employee;
global using DAL.Reporsitories;
global using DAL.Entities;

namespace BLL.Services;

public class EmployeeService(IEmployeeRepository repository, IMapper mapper) : IEmployeeService
{
    
    public int Add(EmployeeRequest request)
    {
       var employee = mapper.Map<EmployeeRequest, Employee>(request);
        return repository.Add(employee);
    }

    public bool Delete(int id) {
        var Employee = repository.GetById(id);
        if (Employee is null) return false;
        var result = repository.Delete(Employee);
        return result > 0;
    }
    public IEnumerable<EmployeeResponse> GetAll() {
        var employee = repository.GetAllQuery().Select(
                e => new EmployeeResponse
                {
                    Age = e.Age,
                    Email = e.Email,
                    Name = e.Name,
                }
            ).ToList();
        return employee;
        //return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(employee);
    }

    public EmployeeDetailedResponse? GetById(int id)
    {
        var Employee = repository.GetById(id);
        return Employee?.ToString();
    }

    public int Update(EmployeeUpdateRequest employee) => repository.Update(Employee.ToEntity());

    
}
