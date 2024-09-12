using Microsoft.AspNetCore.Mvc;

namespace API.Middleware.Models
{
    public class CustomValidationProblemDetails : ProblemDetails
    {
       public IDictionary<string, string[]>? Errors { get; set; }
    }
}
