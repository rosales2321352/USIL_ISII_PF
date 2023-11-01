namespace WebApp.Helpers;

public class ApiResponseError
{
    public int StatusCode { get; set; }
    public string Data { get; set; } = null!;

}