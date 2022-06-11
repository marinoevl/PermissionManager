using PermissionManager.Application.Common.Dtos.Permissions;

namespace PermissionManager.Application.Common.Interfaces.Services;

public interface IGetPermissionById
{
    Task<PermissionResponse> Invoke(GetPermissionByIdRequest request, CancellationToken cancellationToken);
}