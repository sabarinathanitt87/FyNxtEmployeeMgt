using FyNxtEmployeeMgt.Models;
using FyNxtEmployeeMgt.Service.IService;
using FyNxtEmployeeMgt.Utility;

namespace FyNxtEmployeeMgt.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseService _baseService;
        public EmployeeService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateEmployeesAsync(EmployeeDto EmployeeDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Api.ApiType.POST,
                Data = EmployeeDto,
                Url = Api.EmployeeAPIBase + "/api/Employees"
            });
        }

        public async Task<ResponseDto?> DeleteEmployeesAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Api.ApiType.DELETE,
                Url = Api.EmployeeAPIBase + "/api/Employees/" + id
            });
        }

        public async Task<ResponseDto?> GetAllEmployeesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Api.ApiType.GET,
                Url = Api.EmployeeAPIBase + "/api/Employees"
            });
        }
        public async Task<ResponseDto?> GetAllDepartmentsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Api.ApiType.GET,
                Url = Api.EmployeeAPIBase + "/api/Departments"
            });
        }

        public async Task<ResponseDto?> GetEmployeeAsync(string EmployeeCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Api.ApiType.GET,
                Url = Api.EmployeeAPIBase + "/api/Employee/GetByCode/" + EmployeeCode
            });
        }

        public async Task<ResponseDto?> GetEmployeeByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Api.ApiType.GET,
                Url = Api.EmployeeAPIBase + "/api/Employees/" + id
            });
        }

        public async Task<ResponseDto?> UpdateEmployeesAsync(EmployeeDto EmployeeDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Api.ApiType.PUT,
                Data = EmployeeDto,
                Url = Api.EmployeeAPIBase + "/api/Employees"
            });
        }
    }
}
