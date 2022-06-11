namespace PermissionManager.Application.Common.Exceptions;

public class NullArgumentException : ArgumentException
{
    public NullArgumentException(string param)
        : base($"The parameter {param} can not be null.", param)
    {
    }
}