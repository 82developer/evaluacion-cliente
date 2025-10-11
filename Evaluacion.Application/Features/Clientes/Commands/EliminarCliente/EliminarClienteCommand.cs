using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Features.Clientes.Commands.EliminarCliente
{
    public class EliminarClienteCommand: IRequest<bool>
    {
        public EliminarClienteCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
