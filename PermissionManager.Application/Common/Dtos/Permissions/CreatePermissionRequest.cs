namespace PermissionManager.Application.Common.Dtos;

public class CreatePermissionRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PermissionTypeId { get; set; }
    public DateTime PermissionDate { get; set; }
}