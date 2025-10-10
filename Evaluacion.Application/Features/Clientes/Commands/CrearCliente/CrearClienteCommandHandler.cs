using MediatR;

namespace Evaluacion.Application.Features.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommandHandler
        : IRequestHandler<CrearClienteCommand, int>
    {
        public async Task<int> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
