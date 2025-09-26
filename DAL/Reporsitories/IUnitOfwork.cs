namespace DAL.Reporsitories;

public interface IUnitOfwork
{
    IEmployeeRepository Employees { get;}
    IDepartmentRepository Departments { get;}

    int Delete(object employee);
    int saveChanges();
}
