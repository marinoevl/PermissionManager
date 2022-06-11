using PermissionManager.Application.Common.Dtos.Permissions;

namespace PermissionManager.Application.Common.Interfaces.Services;

public interface IDeletePermission
{
    Task Invoke(DeletePermissionByIdRequest request, CancellationToken cancellationToken);
}