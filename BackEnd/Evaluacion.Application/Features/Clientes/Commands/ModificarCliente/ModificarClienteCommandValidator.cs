using FluentValidation;

namespace Evaluacion.Application.Features.Clientes.Commands.ModificarCliente
{
    public class ModificarClienteCommandValidator
                 : AbstractValidator<ModificarClienteCommand>
    {
        public ModificarClienteCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("El Id es requerido.");
            RuleFor(x => x.Ruc)
                .NotEmpty()
                .WithMessage("El RUC es obligatorio.");
            RuleFor(x => x.RazonSocial)
                .NotEmpty()
                .WithMessage("El RazonSocial es obligatorio.");
            RuleFor(x => x.TelefonoContacto)
                .NotEmpty()
                .WithMessage("El Telefono es obligatorio.");
            RuleFor(x => x.CorreoContacto)
                .NotEmpty()
                .WithMessage("El Correo es obligatorio.");
        }
    }
}
