using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PermissionManager.Application.Common.Dtos;
using PermissionManager.Application.Common.Exceptions;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Application.Common.Interfaces.Services;
using ValidationException = PermissionManager.Application.Common.Exceptions.ValidationException;

namespace PermissionManager.Application.Permissions.Commands;

public class UpdatePermission : IUpdatePermission
{
    private readonly IApplicationDbContext _context;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IValidator<UpdatePermissionRequest>  _validator;

    public UpdatePermission(IApplicationDbContext context, 
        IValidator<UpdatePermissionRequest> validator, IPermissionRepository permissionRepository)
    {
        _context = context;
        _validator = validator;
        _permissionRepository = permissionRepository;
    }

    public async Task Invoke(UpdatePermissionRequest request, CancellationToken cancellationToken)
    {
        if (request == null) throw new NullArgumentException(nameof(UpdatePermissionRequest));
        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var entityExists = await _permissionRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entityExists == null) throw new NotFoundException(nameof(UpdatePermissionRequest), request.Id.ToString());

        entityExists.FirstName = request.FirstName;
        entityExists.LastName = request.LastName;
        entityExists.PermissionTypeId = request.PermissionTypeId;
        entityExists.PermissionDate = request.PermissionDate;

        await _context.SaveChangesAsync(cancellationToken);
    }
}