using System.ComponentModel.DataAnnotations;

namespace FyNxtEmployeeMgtApi.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}
