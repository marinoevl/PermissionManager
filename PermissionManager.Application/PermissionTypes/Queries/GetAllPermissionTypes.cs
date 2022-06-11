using PermissionManager.Application.Common.Dtos.PermissionTypes;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Application.Common.Interfaces.Services;

namespace PermissionManager.Application.PermissionTypes.Queries;

public class GetAllPermissionTypes : IGetAllPermissionTypes
{
    private readonly IPermissionTypeRepository _permissionTypeRepository;

    public GetAllPermissionTypes(IPermissionTypeRepository permissionTypeRepository)
    {
        this._permissionTypeRepository = permissionTypeRepository;
    }

    public IEnumerable<PermissionTypesReponse> Invoke()
    {
        var result = _permissionTypeRepository.GetAll();

        return result
            .Select(m => new PermissionTypesReponse
            {
                Id = m.Id,
                Description = m.Description
            })
            .OrderBy(m => m.Description);
    }
}