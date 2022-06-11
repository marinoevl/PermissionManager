using FluentValidation.Results;

namespace PermissionManager.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() 
        :base("Some validations have failed")
    {
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(fg => fg.Key, fg => fg.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}