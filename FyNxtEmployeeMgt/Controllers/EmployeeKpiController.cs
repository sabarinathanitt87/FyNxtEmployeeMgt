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
        private readonly ILogger<EmployeeKpiController> _logger;
        public EmployeeKpiController(IEmployeeKpiService EmployeeKpiService, ILogger<EmployeeKpiController> logger)
        {
            _EmployeeKpiService = EmployeeKpiService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Char page viewed.");
            List<EmployeeKPI>? list = new();


            ResponseDto? response = await _EmployeeKpiService.GetAllEmployeeKpiAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeKPI>>(Convert.ToString(response.Result));
            }
            else
            {
                _logger.LogError(response?.Message);
            }
            
            return View(list);
        }
    }
}
