using Microsoft.AspNetCore.Mvc;
using PermissionManager.Application.Common.Interfaces.Services;

namespace PermissionManager.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionTypesController : ControllerBase
{
    private readonly IGetAllPermissionTypes _getAllPermissionTypes;

    public PermissionTypesController(
        IGetAllPermissionTypes getAllPermissionTypes)
    {
        _getAllPermissionTypes = getAllPermissionTypes;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var type = _getAllPermissionTypes.Invoke().ToList();
        return Ok(type);
    }
}