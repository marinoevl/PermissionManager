using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PermissionManager.Application.Common.Exceptions;

namespace PermissionManager.WebAPI.Filters;

public class ApiExceptionFilterAttribute: ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _actions;

    public ApiExceptionFilterAttribute()
    {
        _actions = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(ValidationException), HandleValidationException },
            { typeof(DuplicateException), HandleDuplicateException },
            { typeof(NullArgumentException), HandleNullArgumentException },
            { typeof(NotFoundException), HandleNotFountException }
        };
    }

    private void HandleNotFountException(ExceptionContext context)
    {
        var exception = context.Exception as NotFoundException;

        var details = new ProblemDetails()
        {
            Type = "Details....",
            Title = "Not Found",
            Detail = exception?.Message
        };

        context.Result = new NotFoundObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleNullArgumentException(ExceptionContext context)
    {
        var exception = context.Exception as NullArgumentException;

        var details = new ValidationProblemDetails()
        {
            Type = "Details....",
            Detail = exception?.Message
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleDuplicateException(ExceptionContext context)
    {
        
        var exception = context.Exception as DuplicateException;

        var details = new ValidationProblemDetails()
        {
            Type = "Details...."
        };

        context.Result = new ConflictObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleValidationException(ExceptionContext context)
    {
        
        var exception = context.Exception as ValidationException;

        var details = new ValidationProblemDetails(exception.Errors)
        {
            Type = "Details...."
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);
        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        var type = context.Exception.GetType();
        if (_actions.ContainsKey(type))
        {
            _actions[type].Invoke(context);
            return;
        }

        HandleUnknownException(context);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        var details = new ProblemDetails()
        {
            Type = "Details....",
            Title = "Not Found",
            Status = StatusCodes.Status500InternalServerError
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
        context.ExceptionHandled = true;   
    }
}