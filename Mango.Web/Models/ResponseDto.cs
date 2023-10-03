namespace Mango.Web.Models
{
    public class ResponseDto<T>
    {
        public bool IsSuccess { get; set; } = true;
        public T Resposne { get; set; }

        public string Message { get; set; }

        public static ResponseDto<T> CreateResponseDto(T DataValue)
        {
            ResponseDto<T> Response = new ResponseDto<T>();
            if (DataValue != null)
            {
                Response.Resposne = DataValue;
            }
            return Response;
        }
        public static ResponseDto<T> CreateFailureResponseDto(Exception e)
        {
            ResponseDto<T> Response = new ResponseDto<T>();
            if (e != null)
            {
                Response.Message = e.Message;
                Response.IsSuccess = false;
            }
            return Response;
        }
    }
}
