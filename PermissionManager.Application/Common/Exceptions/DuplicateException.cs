namespace PermissionManager.Application.Common.Exceptions;

public class DuplicateException : Exception
{
    public DuplicateException(string name, object key) 
        :base($"Entity \"{name}\" ({key} already exists.")
    {
    }
}