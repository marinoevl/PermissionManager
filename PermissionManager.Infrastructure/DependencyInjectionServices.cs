using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Infrastructure.Persistence;
using PermissionManager.Infrastructure.Persistence.Repositories;
using PermissionManager.Infrastructure.SeedData;

namespace PermissionManager.Infrastructure;

public static class DependencyInjectionServices
{
    public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => { b.MigrationsAssembly(string.Concat(typeof(ApplicationDbContext).Assembly.FullName)); });
        });

        service.AddScoped(typeof(IApplicationDbContext), typeof(ApplicationDbContext));
        service.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
        service.AddScoped(typeof(IPermissionTypeRepository), typeof(PermissionTypeRepository));
    }

    public static async void UseSeedData(
        this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.IsSqlServer())
                context.Database.Migrate();

            await ContextSeedData.SeedDefaultPermissionType(context);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}