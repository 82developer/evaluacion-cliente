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
          : IRequestHandler<EliminarClienteCommand, int>
    {

        private readonly IClienteRepository _clienteRepository;
        public EliminarClienteCommandHandler(
            IClienteRepository clienteRepository
            )
        {
           _clienteRepository = clienteRepository; 
        }
        public async Task<int> Handle(EliminarClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await _clienteRepository.EliminarAsync(request.Id);
            return 1;
        }
    }
}
