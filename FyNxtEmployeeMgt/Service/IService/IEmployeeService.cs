using FyNxtEmployeeMgt.Models;

namespace FyNxtEmployeeMgt.Service.IService
{
    public interface IEmployeeService
    {
        Task<ResponseDto?> GetEmployeeAsync(string EmployeeCode);
        Task<ResponseDto?> GetAllEmployeesAsync();
        Task<ResponseDto?> GetAllDepartmentsAsync();
        Task<ResponseDto?> GetEmployeeByIdAsync(int id);
        Task<ResponseDto?> CreateEmployeesAsync(EmployeeDto EmployeeDto);
        Task<ResponseDto?> UpdateEmployeesAsync(EmployeeDto EmployeeDto);
        Task<ResponseDto?> DeleteEmployeesAsync(int id);
    }
}
