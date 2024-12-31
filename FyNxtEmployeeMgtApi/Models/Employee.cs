using System.ComponentModel.DataAnnotations;

namespace FyNxtEmployeeMgtApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }

        // Navigation property
        public Department Department { get; set; }
    }
}
