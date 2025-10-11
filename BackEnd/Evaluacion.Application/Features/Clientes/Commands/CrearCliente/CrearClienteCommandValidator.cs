using FluentValidation;

namespace Evaluacion.Application.Features.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommandValidator
                 : AbstractValidator<CrearClienteCommand>
    {
        public CrearClienteCommandValidator()
        {
            RuleFor(x => x.Ruc)
                .NotEmpty()
                .WithMessage("El RUC es obligatorio.");
            RuleFor(x => x.RazonSocial)
                .NotEmpty()
                .WithMessage("El RazonSocial es obligatorio.");
            RuleFor(x => x.Telefono)
                .NotEmpty()
                .WithMessage("El Telefono es obligatorio.");
            RuleFor(x => x.Correo)
                .NotEmpty()
                .WithMessage("El Correo es obligatorio.");
        }
    }
}
