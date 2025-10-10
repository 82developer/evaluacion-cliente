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
        public Task<int> Handle(EliminarClienteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
