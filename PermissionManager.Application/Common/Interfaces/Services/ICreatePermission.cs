using PermissionManager.Application.Common.Dtos;

namespace PermissionManager.Application.Common.Interfaces.Services;

public interface ICreatePermission
{
    Task Invoke(CreatePermissionRequest request, CancellationToken cancellationToken);
}