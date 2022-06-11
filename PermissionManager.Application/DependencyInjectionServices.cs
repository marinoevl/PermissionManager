using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PermissionManager.Application.Common.Interfaces.Services;
using PermissionManager.Application.Permissions.Commands;
using PermissionManager.Application.Permissions.Queries;
using PermissionManager.Application.PermissionTypes.Queries;

namespace PermissionManager.Application;

public static class DependencyInjectionServices
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(ICreatePermission), typeof(CreatePermission));
        services.AddTransient(typeof(IDeletePermission), typeof(DeletePermission));
        services.AddTransient(typeof(IGetAllPermissions), typeof(GetAllPermissions));
        services.AddTransient(typeof(IGetAllPermissionTypes), typeof(GetAllPermissionTypes));
        services.AddTransient(typeof(IGetPermissionById), typeof(GetPermissionById));
        services.AddTransient(typeof(IUpdatePermission), typeof(UpdatePermission));
    }
}