using BLL.DataTransferObject.Department;
using DAL.Entities;
using DAL.Reporsitories;

namespace BLL.Services;

public class DepartmentService(IUnitOfwork unitOfWork) : IDepartmentService
{
    public int Create(DepartmentRequest request)
    {
            unitOfWork.Departments.Add(request.ToEntity());
        return unitOfWork.saveChanges(); 
    }

    public DepartmentDetailResponse? GetById(int id)
    {
        var department = unitOfWork.Departments.GetById(id);
        if (department == null) return null;

        return new DepartmentDetailResponse
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            CreatedAt = department.CreatedAt
        };
    }

    public IEnumerable<DepartmentDetailResponse> GetAll()
    {
        var departments = unitOfWork.Departments.GetAllQuery();
        return departments.Select(department => new DepartmentDetailResponse
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            CreatedAt = department.CreatedAt
        });
    }

    public int Update(DepartmentUpdateRequest request)
    {
        var department = unitOfWork.Departments.GetById(request.Id);
        if (department == null) return 0;

        department.Name = request.Name;
        department.Code = request.Code;
        department.Description = request.Description;

            unitOfWork.Departments.Update(department);
        return unitOfWork.saveChanges(); 
    }

    public bool Delete(int id)
    {
        var department = unitOfWork.Departments.GetById(id);
        if (department == null) return false;

        unitOfWork.Departments.Delete(department);
        return true;
    }

    public int Add(DepartmentRequest request)
    {
            unitOfWork.Departments.Add(request.ToEntity());
        return unitOfWork.saveChanges(); 
    }

    int IDepartmentService.Delete(int id)
    {
        throw new NotImplementedException();
    }
}
