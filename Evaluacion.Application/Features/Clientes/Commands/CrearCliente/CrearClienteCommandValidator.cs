using FluentValidation;

namespace Evaluacion.Application.Features.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommandValidator
                 : AbstractValidator<CrearClienteCommand>
    {
        public CrearClienteCommandValidator()
        {
        }
    }
}
