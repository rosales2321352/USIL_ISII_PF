namespace WebApp.Helpers
{
    public class ApiSingleObjectResponse<T>
    {
        public int StatusCode { get; set; }
        public object Data { get; set; } = default!;
        public ApiSingleObjectResponse(object data, int statusCode)
        {
            StatusCode = statusCode;
            Data = data;
        }
    }
}

