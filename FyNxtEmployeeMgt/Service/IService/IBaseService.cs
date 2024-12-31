using FyNxtEmployeeMgt.Models;

namespace FyNxtEmployeeMgt.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
