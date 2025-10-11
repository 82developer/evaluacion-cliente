using AutoMapper;
using Evaluacion.Application.Dtos;
using Evaluacion.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Features.Clientes.Queries.BuscarPorIdCliente
{
    public class BuscarPorIdClienteQueryHandler
        : IRequestHandler<BuscarPorIdClienteQuery, ClienteDto>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public BuscarPorIdClienteQueryHandler(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDto> Handle(BuscarPorIdClienteQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ObtenerPorIdAsync(request.Id);
            var response = _mapper.Map<ClienteDto>(cliente);
            return response;
        }
    }
}
