using Mango.Web.Models;

namespace Mango.Web.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDto<T>?> SendAsync<T>(RequestDto requestDto);
    }
}
