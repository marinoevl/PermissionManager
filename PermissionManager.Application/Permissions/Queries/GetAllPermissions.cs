using Microsoft.EntityFrameworkCore;
using PermissionManager.Application.Common.Dtos.Permissions;
using PermissionManager.Application.Common.Exceptions;
using PermissionManager.Application.Common.Extensions;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Application.Common.Interfaces.Services;
using PermissionManager.Application.Common.Models;

namespace PermissionManager.Application.Permissions.Queries;

internal class GetAllPermissions : IGetAllPermissions
{
    private readonly IPermissionRepository _permissionRepository;

    public GetAllPermissions(IPermissionRepository permissionRepository)
    {
        this._permissionRepository = permissionRepository;
    }

    public async Task<PaginatedItems<PermissionsDto>> Invoke(GetAllPermissionsRequest request,
        CancellationToken cancellationToken)
    {
        if (request == null) throw new NullArgumentException(nameof(GetAllPermissionsRequest));

        var result = _permissionRepository.GetAll();

        return await result
            .Include(m => m.PermissionType)
            .Select(m => new PermissionsDto
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                PermissionType = m.PermissionType.Description,
                DateAt = m.PermissionDate
            })
            .OrderBy(m => m.FirstName)
            .ThenBy(m => m.LastName)
            .PaginatedListAsync(request.PagePosition, request.ItemsPerPage, cancellationToken);
    }
}