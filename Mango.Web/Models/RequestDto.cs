namespace Mango.Web.Models
{
    using static Mango.Web.Utility.SD;

    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string URL { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
