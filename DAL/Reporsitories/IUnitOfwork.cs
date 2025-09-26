namespace DAL.Reporsitories;

public interface IUnitOfwork : IDisposable
{
    IEmployeeRepository Employees { get;}
    IDepartmentRepository Departments { get;}
    int saveChanges();
}
