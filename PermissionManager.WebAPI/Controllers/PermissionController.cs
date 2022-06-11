using Microsoft.AspNetCore.Mvc;
using PermissionManager.Application.Common.Dtos;
using PermissionManager.Application.Common.Dtos.Permissions;
using PermissionManager.Application.Common.Interfaces.Services;
using PermissionManager.WebAPI.ViewModel;

namespace PermissionManager.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly ICreatePermission _createPermission;
    private readonly IDeletePermission _deletePermission;
    private readonly IGetAllPermissions _getAllPermissions;
    private readonly IGetAllPermissionTypes _getAllPermissionTypes;
    private readonly IGetPermissionById _getPermissionById;
    private readonly IUpdatePermission _updatePermission;

    public PermissionController(
        IGetAllPermissions getAllPermissions,
        ICreatePermission createPermission,
        IGetPermissionById getPermissionById,
        IUpdatePermission updatePermission,
        IDeletePermission deletePermission,
        IGetAllPermissionTypes getAllPermissionTypes)
    {
        _getAllPermissions = getAllPermissions;
        _getPermissionById = getPermissionById;
        _updatePermission = updatePermission;
        _deletePermission = deletePermission;
        _getAllPermissionTypes = getAllPermissionTypes;
        _createPermission = createPermission;
    }

    [HttpGet("{pagePosition}/{pageSize}")]
    public async Task<IActionResult> Index(int pagePosition, int pageSize, CancellationToken cancellationToken)
    {
        return Ok(await _getAllPermissions.Invoke(new GetAllPermissionsRequest(pagePosition, pageSize),
            cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var permission = await _getPermissionById.Invoke(new GetPermissionByIdRequest(id), cancellationToken);
        var type = _getAllPermissionTypes.Invoke().ToList();
        return Ok(new PermissionDetailViewModel(permission, type));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePermissionRequest createPermissionRequest,
        CancellationToken cancellationToken)
    {
        await _createPermission.Invoke(createPermissionRequest, cancellationToken);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdatePermissionRequest updatePermissionRequest,
        CancellationToken cancellationToken)
    {
        await _updatePermission.Invoke(updatePermissionRequest, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _deletePermission.Invoke(new DeletePermissionByIdRequest(id), cancellationToken);
        return Ok();
    }
}