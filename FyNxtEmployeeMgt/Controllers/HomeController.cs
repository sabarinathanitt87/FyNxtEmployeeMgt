using System.Diagnostics;
using FyNxtEmployeeMgt.Models;
using FyNxtEmployeeMgt.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FyNxtEmployeeMgt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _EmployeeService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService EmployeeService)
        {
            _logger = logger;
            _EmployeeService = EmployeeService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<string> GetEmployees()
        {
            List<EmployeeDto>? list = new();


            ResponseDto? response = await _EmployeeService.GetAllEmployeesAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(response.Result));
            }
            var result = JsonConvert.SerializeObject(new { data = list });
            return result;

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
