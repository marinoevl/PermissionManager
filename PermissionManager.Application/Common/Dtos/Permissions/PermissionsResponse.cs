namespace PermissionManager.Application.Common.Dtos.Permissions;

public class PermissionsDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PermissionType { get; set; }
    public DateTime DateAt { get; set; }
}