namespace WebApp.Helpers
{
    public class ApiSingleObjectResponse<T>
    {
        public int StatusCode { get; set; }
        public object Data { get; set; } = default!;
        public string Message { get; set; }
        public ApiSingleObjectResponse(object data, int statusCode, string message)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }
    }
}

