using PermissionManager.Domain.Entities;

namespace PermissionManager.Application.Common.Dtos.Permissions;

public class PermissionResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PermissionTypeId { get; set; }
    public string PermissionDate { get; set; }

    public ICollection<PermissionType> PermissionType { get; set; }
}