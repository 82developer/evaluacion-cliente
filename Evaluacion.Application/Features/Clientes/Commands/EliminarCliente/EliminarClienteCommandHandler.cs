using Evaluacion.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Features.Clientes.Commands.EliminarCliente
{
    public class EliminarClienteCommandHandler
          : IRequestHandler<EliminarClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _uow;
        public EliminarClienteCommandHandler(
            IClienteRepository clienteRepository ,
            IUnitOfWork uow)
        {
            _clienteRepository = clienteRepository;
            _uow = uow;
        }
        public async Task<bool> Handle(EliminarClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _uow.BeginTransactionAsync();
                var result = await _clienteRepository.EliminarAsync(request.Id);
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
