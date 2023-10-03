using Mango.Web.Models;
using Mango.Web.Services.IService;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        private IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto<T>?> SendAsync<T>(RequestDto requestDto)
        {
            try
            {
                HttpClient httpClient = this._httpClientFactory.CreateClient("MangoApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestDto.URL);
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }
                switch (requestDto.ApiType)
                {
                    case Utility.SD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case Utility.SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Utility.SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Utility.SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        break;
                }
                HttpResponseMessage response = null;
                response = httpClient.SendAsync(message).Result;
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new ResponseDto<T> { IsSuccess = false, Message = "Not Found" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new ResponseDto<T> { IsSuccess = false, Message = "Access Denied" };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new ResponseDto<T> { IsSuccess = false, Message = "UnAuthorized" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new ResponseDto<T> { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await response.Content.ReadAsStringAsync();
                        var responseDto = JsonConvert.DeserializeObject<ResponseDto<T>>(apiContent);
                        return responseDto;

                }

            }
            catch (Exception ex)
            {
                return ResponseDto<T>.CreateFailureResponseDto(ex);
            }

        }
    }
}
