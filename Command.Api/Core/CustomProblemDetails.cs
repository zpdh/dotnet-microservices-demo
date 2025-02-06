using Command.Domain.Core;

namespace Command.Api.Core;

public class CustomProblemDetails
{
    public string Title { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public string Details { get; set; } = string.Empty;
    public Error[]? Errors { get; set; }
    
    private CustomProblemDetails()
    {

    }

    private CustomProblemDetails(string title, int statusCode, string details, Error[]? errors)
    {
        Title = title;
        StatusCode = statusCode;
        Details = details;
        Errors = errors;
    }

    public static CustomProblemDetails Create(string title, int statusCode, string details, Error[]? errors = null)
    {
        return new CustomProblemDetails(title, statusCode, details, errors);
    }
}