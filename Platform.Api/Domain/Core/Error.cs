namespace Platform.Api.Domain.Core;

public class Error(string errorMessage)
{
    public readonly string ErrorMessage = errorMessage;

    public static readonly Error None = new(string.Empty);
    public static readonly Error NullArgument = new("The specified value is null.");
    public static readonly Error ConditionNotMet = new("The specified condition was not met.");

    public static implicit operator Result(Error error)
    {
        return Result.Failure(error);
    }
}