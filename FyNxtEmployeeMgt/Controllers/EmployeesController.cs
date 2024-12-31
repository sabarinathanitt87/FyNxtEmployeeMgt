using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FyNxtEmployeeMgt.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeesController(IEmployeeService EmployeeService)
        {
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
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            List<DepartmentDto>? listDepartment = new();
            ResponseDto? responseDept = await _EmployeeService.GetAllDepartmentsAsync();
            listDepartment = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(responseDept.Result));
            var departmentList = new List<SelectListItem>();
            for (int i = 0; i < listDepartment.Count; i++)
            {
                departmentList.Add(new SelectListItem { Text = listDepartment[i].DepartmentName, Value = listDepartment[i].DepartmentId.ToString() });
            }

            ViewBag.DepartmentList = departmentList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _EmployeeService.CreateEmployeesAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Employee created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _EmployeeService.UpdateEmployeesAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Employee updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int EmployeeId)
        {
            ResponseDto? response = await _EmployeeService.GetEmployeeByIdAsync(EmployeeId);

            if (response != null && response.IsSuccess)
            {
                EmployeeDto? model = JsonConvert.DeserializeObject<EmployeeDto>(Convert.ToString(response.Result));
                List<DepartmentDto>? listDepartment = new();
                ResponseDto? responseDept = await _EmployeeService.GetAllDepartmentsAsync();
                listDepartment = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(responseDept.Result));
                var departmentList = new List<SelectListItem>();
                for (int i = 0; i < listDepartment.Count; i++)
                {
                    departmentList.Add(new SelectListItem { Text = listDepartment[i].DepartmentName, Value = listDepartment[i].DepartmentId.ToString() });
                }

                ViewBag.DepartmentList = departmentList;
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }
        public async Task<IActionResult> Delete(int EmployeeId)
        {
            ResponseDto? response = await _EmployeeService.GetEmployeeByIdAsync(EmployeeId);

            if (response != null && response.IsSuccess)
            {
                EmployeeDto? model = JsonConvert.DeserializeObject<EmployeeDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeDto EmployeeDto)
        {
            ResponseDto? response = await _EmployeeService.DeleteEmployeesAsync(EmployeeDto.EmployeeId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Employee deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(EmployeeDto);
        }
    }
}
