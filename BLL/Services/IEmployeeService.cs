using BLL.DataTransferObject.Employee;

namespace BLL.Services;

public interface IEmployeeService
{
    EmployeeDetailedResponse? GetById(int id);
    IEnumerable<EmployeeResponse> GetAll();

    int Add(EmployeeRequest request);
    int Update(EmployeeUpdateRequest request);
    bool Delete(int id);

}
