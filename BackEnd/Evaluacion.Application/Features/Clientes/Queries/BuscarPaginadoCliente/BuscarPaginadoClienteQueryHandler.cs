using AutoMapper;
using Evaluacion.Application.Dtos;
using Evaluacion.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Features.Clientes.Queries.BuscarPaginadoCliente
{
    public class BuscarPaginadoClienteQueryHandler
        : IRequestHandler<BuscarPaginadoClienteQuery, IEnumerable<ClienteDto>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public BuscarPaginadoClienteQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<ClienteDto>> Handle(BuscarPaginadoClienteQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
