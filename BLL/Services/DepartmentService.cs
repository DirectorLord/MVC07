using BLL.DataTransferObject.Department;
using DAL.Entities;
using DAL.Reporsitories;

namespace BLL.Services;

public class DepartmentService(IDepartmentRepository repository) : IDepartmentService
{
    public int Create(DepartmentRequest request)
    {
        return repository.Add(request.ToEntity());
    }

    public DepartmentDetailResponse? GetById(int id)
    {
        var department = repository.GetById(id);
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
        var departments = repository.GetAllQuery();
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
        var department = repository.GetById(request.Id);
        if (department == null) return 0;

        department.Name = request.Name;
        department.Code = request.Code;
        department.Description = request.Description;

        return repository.Update(department);
    }

    public bool Delete(int id)
    {
        var department = repository.GetById(id);
        if (department == null) return false;

        repository.Delete(department);
        return true;
    }

    public int Add(DepartmentRequest request)
    {
        return repository.Add(request.ToEntity());
    }

    int IDepartmentService.Delete(int id)
    {
        throw new NotImplementedException();
    }
}
