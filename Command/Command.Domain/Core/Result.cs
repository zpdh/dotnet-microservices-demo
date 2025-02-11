namespace Command.Domain.Core;

public class Result
{
    public Error Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(Error err)
    {
        Error = err;

        if (Error == Error.None)
        {
            IsSuccess = true;
            return;
        }

        IsSuccess = false;
    }

    public static Result Create(bool condition)
    {
        return condition
            ? Success()
            : Failure(Error.ConditionNotMet);
    }

    public static Result<TValue> Create<TValue>(TValue? value)
    {
        return value is not null
            ? Success<TValue>(value)
            : Failure<TValue>(Error.NullArgument);
    }

    public static Result Success()
    {
        return new Result(Error.None);
    }

    public static Result<TValue> Success<TValue>(TValue value)
    {
        return new Result<TValue>(value, Error.None);
    }

    public static Result Failure(Error err)
    {
        return new Result(err);
    }

    public static Result<TValue> Failure<TValue>(Error err)
    {
        return new Result<TValue>(default, err);
    }
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failed result cannot be accessed.");

    public Result(TValue? value, Error error) : base(error)
    {
        _value = value;
    }

    public static implicit operator Result<TValue>(TValue? value)
    {
        return Create(value);
    }
}