using FyNxtEmployeeMgt.Models;
using FyNxtEmployeeMgt.Service;
using FyNxtEmployeeMgt.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FyNxtEmployeeMgt.Controllers
{
    public class EmployeeKpiController : Controller
    {
        private readonly IEmployeeKpiService _EmployeeKpiService;
        public EmployeeKpiController(IEmployeeKpiService EmployeeKpiService)
        {
            _EmployeeKpiService = EmployeeKpiService;
        }
        public async Task<IActionResult> Index()
        {
            List<EmployeeKPI>? list = new();


            ResponseDto? response = await _EmployeeKpiService.GetAllEmployeeKpiAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeKPI>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            
            return View(list);
        }
    }
}
