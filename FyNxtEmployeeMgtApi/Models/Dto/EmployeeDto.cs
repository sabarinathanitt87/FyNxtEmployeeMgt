﻿
namespace FyNxtEmployeeMgtApi.Models.Dto
{
    public class EmployeeDto
    {
        public int? EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
