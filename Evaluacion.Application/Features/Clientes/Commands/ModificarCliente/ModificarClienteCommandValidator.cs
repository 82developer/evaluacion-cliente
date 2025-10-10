using FluentValidation;

namespace Evaluacion.Application.Features.Clientes.Commands.ModificarCliente
{
    public class ModificarClienteCommandValidator
                 : AbstractValidator<ModificarClienteCommand>
    {
        public ModificarClienteCommandValidator()
        {
        }
    }
}
