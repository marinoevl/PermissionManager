using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PermissionManager.Application.Common.Dtos;
using PermissionManager.Application.Common.Dtos.Permissions;
using PermissionManager.Application.Common.Exceptions;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Application.Common.Interfaces.Services;
using PermissionManager.Domain.Entities;
using ValidationException = PermissionManager.Application.Common.Exceptions.ValidationException;

namespace PermissionManager.Application.Permissions.Commands;

public class CreatePermission : ICreatePermission
{
    private readonly IApplicationDbContext _context;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IValidator<CreatePermissionRequest> _validator;

    public CreatePermission(IApplicationDbContext context, 
        IValidator<CreatePermissionRequest> validator, 
        IPermissionRepository permissionRepository)
    {
        _context = context;
        _validator = validator;
        _permissionRepository = permissionRepository;
    }

    public async Task Invoke(CreatePermissionRequest request, CancellationToken cancellationToken)
    {
        if (request == null) throw new NullArgumentException(nameof(GetPermissionByIdRequest));
        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var entityExists = await _permissionRepository.GetAll()
            .FirstOrDefaultAsync(m => m.FirstName == request.FirstName && m.LastName == request.LastName,
                cancellationToken);

        if (entityExists != null)
            throw new DuplicateException(nameof(GetPermissionByIdRequest), $"{request.FirstName} {request.LastName}");

        var newPermission = new Permission
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PermissionTypeId = request.PermissionTypeId,
            PermissionDate = request.PermissionDate
        };

        await _permissionRepository.CreateAsync(newPermission, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}