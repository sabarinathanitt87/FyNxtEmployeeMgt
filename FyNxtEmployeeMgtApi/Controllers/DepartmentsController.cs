using AutoMapper;
using FyNxtEmployeeMgtApi.Data;
using FyNxtEmployeeMgtApi.Models;
using FyNxtEmployeeMgtApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FyNxtEmployeeMgtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ResponseDto _response;
        private IMapper _mapper;
        private AuditLog _auditLog;

        public DepartmentsController(ApplicationDbContext context, IMapper mapper)
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
                IEnumerable<Department> objList = _context.Department.ToList();
                _response.Result = _mapper.Map<IEnumerable<DepartmentDto>>(objList);
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
                Department obj = _context.Department.First(u => u.DepartmentId == id);
                _response.Result = _mapper.Map<DepartmentDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] DepartmentDto DepartmentDto)
        {
            try
            {
                Department obj = _mapper.Map<Department>(DepartmentDto);
                _context.Department.Add(obj);
                _context.SaveChanges();
                _response.Result = _mapper.Map<DepartmentDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] DepartmentDto DepartmentDto)
        {
            try
            {
                Department obj = _mapper.Map<Department>(DepartmentDto);
                _context.Department.Update(obj);
                _context.SaveChanges();

                _response.Result = _mapper.Map<DepartmentDto>(obj);
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
                Department obj = _context.Department.First(u => u.DepartmentId == id);
                _context.Department.Remove(obj);
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


        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.DepartmentId == id);
        }
    }
}
