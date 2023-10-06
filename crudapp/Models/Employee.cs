using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crudapp.Models;

[Table("Employees")]
public class Employee
{
    [Key]
    public int Id { get; set; }
    public string EmpName { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    public int EmployeeAge { get; set; }
    public string Address { get; set; }

    [ForeignKey("Department")]
    public int DeptId { get; set; }

    public Department Department { get; set; }
}
