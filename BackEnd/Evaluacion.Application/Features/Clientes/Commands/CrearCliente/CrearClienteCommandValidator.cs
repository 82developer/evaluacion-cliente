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
            RuleFor(x => x.TelefonoContacto)
                .NotEmpty()
                .WithMessage("El Telefono es obligatorio.");
            RuleFor(x => x.CorreoContacto)
                .NotEmpty()
                .WithMessage("El Correo es obligatorio.");
        }
    }
}
