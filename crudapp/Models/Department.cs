using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudapp.Models;

[Table("Departments")]
public class Department
{
    [Key]
    public int Id { get; set; }
    public string DeptName { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
