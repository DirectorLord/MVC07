using BLL.DataTransferObject.Department;

namespace BLL.Services;

public interface IDepartmentService
{
    DepartmentDetailResponse? GetById(int id );
     IEnumerable<DepartmentDetailResponse> GetAll();
    int Update(DepartmentUpdateRequest request);
    int Delete(int id);
    int Add(DepartmentRequest request);
    int Create(DepartmentRequest request);
}
