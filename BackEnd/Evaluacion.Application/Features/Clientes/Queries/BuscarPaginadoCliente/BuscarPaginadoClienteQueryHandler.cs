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
        : IRequestHandler<BuscarPaginadoClienteQuery, PageResult<ClienteDto>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public BuscarPaginadoClienteQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<PageResult<ClienteDto>> Handle(BuscarPaginadoClienteQuery request, CancellationToken cancellationToken)
        {
            var page = await _clienteRepository.ObtenerTodosAsync(
                request.Ruc,
                request.RazonSocial,
                request.NumeroPagina,
                request.tamanioPagina
                );
            return page;
        }
    }
}
