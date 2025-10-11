using AutoMapper;
using Evaluacion.Application.Repositories;
using Evaluacion.Domain;
using MediatR;

namespace Evaluacion.Application.Features.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommandHandler
        : IRequestHandler<CrearClienteCommand, int>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public CrearClienteCommandHandler(
            IClienteRepository clienteRepository,
            IMapper mapper
            )
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Cliente>(request);
            var result = await _clienteRepository.CrearAsync(cliente);
            return result;
        }
    }
}
