using Evaluacion.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Features.Clientes.Queries.BuscarPorIdCliente
{
    public class BuscarPorIdClienteQuery
        :IRequest<ClienteDto>
    {
        public BuscarPorIdClienteQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
