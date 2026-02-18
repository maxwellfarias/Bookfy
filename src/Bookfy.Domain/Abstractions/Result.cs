using System;
using System.Diagnostics.CodeAnalysis;

namespace Bookify.Domain.Abstractions;

public class Result
{
    /// <summary>
    /// The constructor is protected internal to allow only derived classes and classes within the same assembly to create instances of Result.
    /// This is to ensure that the creation of Result instances is controlled and that the rules for success and failure are enforced. By making
    /// the constructor protected internal, we can prevent external code from creating instances of Result directly and potentially violating the
    /// rules for success and failure. Instead, external code must use the provided static methods (Success and Failure) to create instances of Result,
    /// which ensures that the rules are followed consistently throughout the application.
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="error"></param>
    /// <exception cref="InvalidOperationException"></exception>
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException("A successful result cannot have an error.");

        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException("A failure result must have an error.");

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    // default value of TValue is used when the result is a failure, as it is not valid to have a value in a failure result. The default value will be
    // ignored and should not be accessed when the result is a failure. This design enforces the principle that a failure result cannot have a value and
    // should instead provide information about the error that occurred.
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    /// <summary>
    /// The Value property is designed to provide access to the value of a successful result. It is decorated with the [NotNull] attribute to indicate
    /// that it should never return null when the result is successful. If the result is a failure, attempting to access the Value property will throw
    /// an InvalidOperationException, as it is not valid to access the value of a failed result. This design enforces the principle that a successful
    /// result must have a valid value, while a failed result cannot have a value and should instead provide information about the error that occurred.
    /// </summary>
    [NotNull]
    public TValue Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException(
                "The value of a failure result cannot be accessed."
            );

    /// <summary>
    /// The implicit operator allows for the creation of a Result<TValue> instance directly from a TValue value. When a TValue value is assigned to a
    /// variable of type Result<TValue>, the implicit operator is invoked, creating a successful result if the value is not null, or a failure result if
    /// the value is null.
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}
