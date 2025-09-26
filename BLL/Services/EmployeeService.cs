global using AutoMapper;
global using BLL.DataTransferObject.Employee;
global using DAL.Reporsitories;
global using DAL.Entities;
using AutoMapper.QueryableExtensions;

namespace BLL.Services;

public class EmployeeService(IUnitOfwork unitOfwork, IMapper mapper) : IEmployeeService
{
    
    public int Add(EmployeeRequest request)
    {
       var employee = mapper.Map<EmployeeRequest, Employee>(request);
        unitOfwork.Employees.Add(employee);
        return unitOfwork.saveChanges();
    }

    public bool Delete(int id) {
        var Employee = unitOfwork.Employees.GetById(id);
        if (Employee is null) return false;
            unitOfwork.Employees.Delete(Employee);
        return unitOfwork.saveChanges() > 0;
    }
    public IEnumerable<EmployeeResponse> GetAll() {
        //var employee = unitOfWork.GetAllQuery().Select(
        //        e => new EmployeeResponse
        //        {
        //            Age = e.Age,
        //            Email = e.Email,
        //            Name = e.Name,
        //            Department = e.Department.Name,
        //        }
        //    ).ToList();
        //return employee;
        return unitOfwork.Employees.GetAllQuery().ProjectTo<EmployeeResponse>(
            mapper.ConfigurationProvider).ToList();
    }   
    public IEnumerable<EmployeeResponse> GetAll(string searchValue)
    {

        return unitOfwork.GetAllQuery()
            .Where(e => e.Name != null && e.Name.Contains(searchValue.Trim()) ||
                        e.Email != null && e.Email.Contains(searchValue.Trim())) 
            .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider)
            .ToList();
    }

    public EmployeeDetailedResponse? GetById(int id)
    {
        var employee = unitOfwork.Employees.GetById(id);
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

    public int Update(EmployeeUpdateRequest employee) => unitOfWork.Update(Employee.ToEntity());

    
}
