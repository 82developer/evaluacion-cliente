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
        private readonly IUnitOfWork _uow;
        public CrearClienteCommandHandler(
            IClienteRepository clienteRepository,
            IMapper mapper ,
            IUnitOfWork uow)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<int> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _uow.BeginTransactionAsync();
                var cliente = _mapper.Map<Cliente>(request);
                var result = await _clienteRepository.CrearAsync(cliente);
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
