global using AutoMapper;
global using BLL.DataTransferObject.Employee;
global using DAL.Reporsitories;
global using DAL.Entities;

namespace BLL.Services;

public class EmployeeService(IEmployeeRepository repository, IMapper mapper, EmployeeRepository employeeRepository) : IEmployeeService
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
        //var employee = repository.GetAllQuery().Select(
        //        e => new EmployeeResponse
        //        {
        //            Age = e.Age,
        //            Email = e.Email,
        //            Name = e.Name,
        //            Department = e.Department.Name,
        //        }
        //    ).ToList();
        //return employee;
        var employees = employeeRepository.GetAll();
        return mapper.Map<IEnumerable<EmployeeResponse>>(employees);
    }   


    public EmployeeDetailedResponse? GetById(int id)
    {
        var employee = repository.GetById(id);
        if (employee == null) return null;

        return new EmployeeDetailedResponse
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Age = employee.Age,
            Address = employee.Address,
            Salary = employee.Salary,
            IsActive = employee.IsActive,
            PhoneNumber = employee.PhoneNumber,
            HiringDate = employee.HiringDate,
            Gender = employee.Gender,
            EmployeeType = employee.EmployeeType,
            Department = employee.Department?.Name
        };
    }

    public int Update(EmployeeUpdateRequest employee) => repository.Update(Employee.ToEntity());

    
}
