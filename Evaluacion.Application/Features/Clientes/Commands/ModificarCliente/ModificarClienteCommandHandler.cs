using AutoMapper;
using Evaluacion.Application.Repositories;
using Evaluacion.Domain;
using MediatR;

namespace Evaluacion.Application.Features.Clientes.Commands.ModificarCliente
{
    public class ModificarClienteCommandHandler
          : IRequestHandler<ModificarClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ModificarClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }


        public async Task<bool> Handle(ModificarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Cliente>(request);
            var result = await _clienteRepository.ActualizarAsync(cliente);
            return result;
        }
    }
}
