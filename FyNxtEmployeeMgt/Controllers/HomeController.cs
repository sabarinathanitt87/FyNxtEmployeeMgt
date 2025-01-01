using System.Diagnostics;
using FyNxtEmployeeMgt.Models;
using FyNxtEmployeeMgt.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            List<EmployeeDto>? list = new();


            ResponseDto? response = await _EmployeeService.GetAllEmployeesAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [HttpPost]
        public async void Delete(int id)
        {
            ResponseDto? response = await _EmployeeService.GetEmployeeByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                EmployeeDto? model = JsonConvert.DeserializeObject<EmployeeDto>(Convert.ToString(response.Result));
            }
            else
            {
                _logger.LogError(response?.Message);
            }
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
