using System.ComponentModel.DataAnnotations;

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
    [Display(Name = "Employee Type")]
    public string EmployeeType { get; set; }
    public string? Department { get; set; }
}
