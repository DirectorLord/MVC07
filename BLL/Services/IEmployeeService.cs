using BLL.DataTransferObject.Employee;

namespace BLL.Services;

public interface IEmployeeService
{
    IEnumerable<EmployeeResponse> GetAll();
    IEnumerable<EmployeeResponse> GetAll(string? searchValue = null);
    EmployeeDetailedResponse? GetById(int id);
    int Add(EmployeeRequest request);
    int Update(EmployeeUpdateRequest request);
    bool Delete(int id);

}
