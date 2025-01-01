using FyNxtEmployeeMgt.Models;
using FyNxtEmployeeMgt.Service.IService;
using FyNxtEmployeeMgt.Utility;

namespace FyNxtEmployeeMgt.Service
{
    public class EmployeesKpiService : IEmployeeKpiService
    {
        private readonly IBaseService _baseService;
        public EmployeesKpiService(IBaseService baseService)
        {
            _baseService = baseService;
        }

       

       
        public async Task<ResponseDto?> GetAllEmployeeKpiAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Api.ApiType.GET,
                Url = Api.EmployeeAPIBase + "/api/EmployeesKpi"
            });
        }
        
    }
}
