using System.Threading.Tasks;
namespace Application.Common
{
  public class ApiResponse
  {
    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
  }

  public class APIResponseService
  {
    // Generic failure response
    public Task<ApiResponse> ApiFailResponse(string message, bool success = false, object? data = default)
    {
      return Task.FromResult(new ApiResponse
      {
        Success = success,
        Message = message,
        Data = data
      });
    }

    // Success response
    public Task<ApiResponse> ApiSuccessResponse(object? data, string message = "Success", bool success = true)
    {
      return Task.FromResult(new ApiResponse
      {
        Success = success,
        Message = message,
        Data = data
      });
    }
  }
}


