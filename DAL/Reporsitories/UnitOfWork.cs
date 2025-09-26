namespace DAL.Reporsitories;

public class UnitOfWork (CompanyDBContext dbContext, IEmployeeRepository employee, IDepartmentRepository
    department)
    : IUnitOfwork
{
    public IEmployeeRepository Employees => employee;

    public IDepartmentRepository Departments => department;

    public int saveChanges() => dbContext.SaveChanges();
}
