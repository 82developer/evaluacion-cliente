using Evaluacion.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Features.Clientes.Queries.BuscarPaginadoCliente
{
    public class BuscarPaginadoClienteQuery
        :IRequest<PageResult<ClienteDto>>
    {
        public string? Ruc { get; set; } = null;
        public string? RazonSocial { get; set; } = null;
        public int NumeroPagina { get; set; } = 1;
        public int tamanioPagina { get; set; } = 10;
    }
}
