using PermissionManager.Domain.Entities;
using PermissionManager.Infrastructure.Persistence;

namespace PermissionManager.Infrastructure.SeedData;

public class ContextSeedData
{
    public static async Task SeedDefaultPermissionType(ApplicationDbContext context)
    {
        var permissionType = new List<PermissionType>();

        var existingTypes = context.PermissionTypes.DefaultIfEmpty().ToList();

        if (!existingTypes.Any(m => m.Description == "Enfermedad"))
            permissionType.Add(new PermissionType
            {
                Description = "Enfermedad"
            });

        if (!existingTypes.Any(m => m.Description == "Diligencias"))
            permissionType.Add(new PermissionType
            {
                Description = "Diligencias"
            });

        if (!existingTypes.Any(m => m.Description == "Otros"))
            permissionType.Add(new PermissionType
            {
                Description = "Otros"
            });

        await context.PermissionTypes.AddRangeAsync(permissionType);
        await context.SaveChangesAsync();
    }
}