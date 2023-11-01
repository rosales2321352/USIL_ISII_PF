namespace WebApp.Helpers
{
    public class ApiListResponse<T>
    {
        public int StatusCode { get; set; }
        public IEnumerable<object> Data { get; set; } = default!;
        public int TotalRows { get; set; }

        public ApiListResponse(IEnumerable<object> data, int statusCode)
        {
            StatusCode = statusCode;
            Data = data;
            TotalRows = data?.Count() ?? 0;
        }
    }
}

