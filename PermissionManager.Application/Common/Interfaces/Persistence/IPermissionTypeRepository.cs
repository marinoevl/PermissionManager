using PermissionManager.Domain.Entities;

namespace PermissionManager.Application.Common.Interfaces.Persistence;

public interface IPermissionTypeRepository
{
    IQueryable<PermissionType> GetAll();
}