using Evaluacion.Application.Repositories;
using MediatR;

namespace Evaluacion.Application.Features.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommandHandler
        : IRequestHandler<CrearClienteCommand, int>
    {
        private readonly IClienteRepository _clienteRepository;
        public CrearClienteCommandHandler(
            IClienteRepository clienteRepository
            )
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<int> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {

            var result = await _clienteRepository.Crear(null);

            return result;
        }
    }
}
