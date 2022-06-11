using PermissionManager.Application.Common.Dtos.Permissions;
using PermissionManager.Application.Common.Models;

namespace PermissionManager.Application.Common.Interfaces.Services;

public interface IGetAllPermissions
{
    Task<PaginatedItems<PermissionsDto>> Invoke(GetAllPermissionsRequest request, CancellationToken cancellationToken);
}