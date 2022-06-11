using PermissionManager.Application.Common.Dtos;

namespace PermissionManager.Application.Common.Interfaces.Services;

public interface IUpdatePermission
{
    Task Invoke(UpdatePermissionRequest request, CancellationToken cancellationToken);
}