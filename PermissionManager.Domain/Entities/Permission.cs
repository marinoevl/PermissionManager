namespace PermissionManager.Domain.Entities;

public class Permission
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PermissionTypeId { get; set; }
    public DateTime PermissionDate { get; set; }

    public virtual PermissionType PermissionType { get; set; }
}