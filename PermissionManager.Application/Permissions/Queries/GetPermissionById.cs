using PermissionManager.Application.Common.Dtos.Permissions;
using PermissionManager.Application.Common.Exceptions;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Application.Common.Interfaces.Services;

namespace PermissionManager.Application.Permissions.Queries;

public class GetPermissionById : IGetPermissionById
{
    private readonly IPermissionRepository _permissionRepository;

    public GetPermissionById(IPermissionRepository permissionRepository)
    {
        this._permissionRepository = permissionRepository;
    }

    public async Task<PermissionResponse> Invoke(GetPermissionByIdRequest request, CancellationToken cancellationToken)
    {
        if (request == null) throw new NullArgumentException(nameof(GetAllPermissionsRequest));

        var permission = await _permissionRepository.GetByIdAsync(request.Id, cancellationToken);
            
        if (permission == null) throw new NotFoundException(nameof(GetPermissionByIdRequest), request.Id.ToString());

        return new PermissionResponse
        {
            Id = permission.Id,
            FirstName = permission.FirstName,
            LastName = permission.LastName,
            PermissionTypeId = permission.PermissionTypeId,
            PermissionDate = permission.PermissionDate.Date.ToString("yyy-MM-dd")
        };
    }
}