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
        private readonly IUnitOfWork _uow;
        public ModificarClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper, IUnitOfWork uow)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<bool> Handle(ModificarClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _uow.BeginTransactionAsync();
                var cliente = _mapper.Map<Cliente>(request);
                var result = await _clienteRepository.ActualizarAsync(cliente);
                await _uow.SaveChangesAsync(cancellationToken);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
