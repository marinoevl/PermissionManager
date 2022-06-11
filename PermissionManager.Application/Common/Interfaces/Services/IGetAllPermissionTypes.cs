using PermissionManager.Application.Common.Dtos.PermissionTypes;

namespace PermissionManager.Application.Common.Interfaces.Services;

public interface IGetAllPermissionTypes
{
    IEnumerable<PermissionTypesReponse> Invoke();
}