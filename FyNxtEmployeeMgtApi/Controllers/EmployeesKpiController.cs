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
    public class EmployeesKpiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ResponseDto _response;
        private IMapper _mapper;
        private AuditLog _auditLog;

        public EmployeesKpiController(ApplicationDbContext context, IMapper mapper)
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
                IEnumerable<EmployeeKPI> objList = _context.EmployeeKPI.ToList();
                _response.Result = _mapper.Map<IEnumerable<EmployeeKPI>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        
    }
}
