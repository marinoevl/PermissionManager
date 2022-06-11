using FluentValidation;
using PermissionManager.Application.Common.Dtos;

namespace PermissionManager.Application.Permissions.Commands;

public class CreatePermissionValidator: AbstractValidator<CreatePermissionRequest>
{
    public CreatePermissionValidator()
    {
        RuleFor(v => v.FirstName).NotEmpty().NotNull()
            .WithMessage("Debe digitar el nombre");
        RuleFor(v => v.LastName).NotEmpty().NotNull()
            .WithMessage("Debe digitar el apellido");
        RuleFor(v => v.PermissionDate).NotEmpty().NotNull()
            .WithMessage("Debe digitar el la fecha");
        RuleFor(v => v.PermissionTypeId).NotEmpty().NotNull().GreaterThan(0)
            .WithMessage("Debe seleccionar un tipo de permiso");
    }
    
}