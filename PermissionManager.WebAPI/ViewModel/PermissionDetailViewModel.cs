using PermissionManager.Application.Common.Dtos.Permissions;
using PermissionManager.Application.Common.Dtos.PermissionTypes;

namespace PermissionManager.WebAPI.ViewModel;

public class PermissionDetailViewModel
{
    public PermissionDetailViewModel(PermissionResponse permissionResponse,
        IList<PermissionTypesReponse> permissionTypesReponse)
    {
        PermissionResponse = permissionResponse;
        PermissionTypesReponse = permissionTypesReponse;
    }

    public PermissionResponse PermissionResponse { get; set; }
    public IList<PermissionTypesReponse> PermissionTypesReponse { get; set; }
}