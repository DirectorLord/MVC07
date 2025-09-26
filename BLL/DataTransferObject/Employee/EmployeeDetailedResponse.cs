using DAL.Entities.Enum;

namespace BLL.DataTransferObject.Employee;

public class EmployeeDetailedResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public int? Age { get; set; }
    public string? Address { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly HiringDate { get; set; }
    public Gender Gender { get; set; }
    public EmployeeType EmployeeType { get; set; }
    public string? Department { get; set; }
    public int? DepartmentId { get; set; }
}
