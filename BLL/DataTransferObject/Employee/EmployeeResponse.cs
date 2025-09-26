namespace BLL.DataTransferObject.Employee;

public class EmployeeResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Age { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    public string? Email { get; set; }
    public string Gender { get; set; }
    public string EmployeeType { get; set; }
}
