using FyNxtEmployeeMgt.Models;

namespace FyNxtEmployeeMgt.Service.IService
{
    public interface IEmployeeKpiService
    {
        Task<ResponseDto?> GetAllEmployeeKpiAsync();
       
    }
}
