using AutoMapper;
using FyNxtEmployeeMgtApi.Data;
using FyNxtEmployeeMgtApi.Models;
using FyNxtEmployeeMgtApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FyNxtEmployeeMgtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ResponseDto _response;
        private IMapper _mapper;
        private AuditLog _auditLog;

        public EmployeesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new ResponseDto();
            _auditLog = new AuditLog();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Employee> objList = _context.Employee.Include(e => e.Department).ToList();
                _response.Result = _mapper.Map<IEnumerable<EmployeeDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Employee obj = _context.Employee.First(u => u.EmployeeId == id);
                _response.Result = _mapper.Map<EmployeeDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                Employee obj = _mapper.Map<Employee>(employeeDto);
                _auditLog.FirstName = employeeDto.FirstName;
                _auditLog.LastName = employeeDto.LastName;
                _auditLog.Email = employeeDto.Email;
                _auditLog.DepartmentId = employeeDto.DepartmentId;
                _context.Employee.Add(obj);
                _context.SaveChanges();
                _context.AuditLog.Add(_auditLog);
                _context.SaveChanges();
                _response.Result = _mapper.Map<EmployeeDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                Employee obj = _mapper.Map<Employee>(employeeDto);
                _auditLog.FirstName = employeeDto.FirstName;
                _auditLog.LastName = employeeDto.LastName;
                _auditLog.Email = employeeDto.Email;
                _auditLog.DepartmentId = employeeDto.DepartmentId;
                _context.Employee.Update(obj);
                _context.SaveChanges();
                _context.AuditLog.Add(_auditLog);
                _context.SaveChanges();

                _response.Result = _mapper.Map<EmployeeDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Employee obj = _context.Employee.First(u => u.EmployeeId == id);
                _auditLog.FirstName = obj.FirstName;
                _auditLog.LastName = obj.LastName;
                _auditLog.Email = obj.Email;
                _auditLog.DepartmentId = obj.DepartmentId;
                _context.Employee.Remove(obj);
                _context.SaveChanges();
                _context.AuditLog.Add(_auditLog);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
