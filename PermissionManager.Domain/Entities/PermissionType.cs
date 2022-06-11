namespace PermissionManager.Domain.Entities;

public class PermissionType
{
    public int Id { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; }
}