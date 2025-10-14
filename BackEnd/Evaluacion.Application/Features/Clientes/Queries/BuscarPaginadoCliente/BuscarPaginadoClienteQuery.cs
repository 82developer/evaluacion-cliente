using Evaluacion.Application.Dtos;
using MediatR;

namespace Evaluacion.Application.Features.Clientes.Queries.BuscarPaginadoCliente;
public sealed record BuscarPaginadoClienteQuery(
    string? Ruc = null,
    string? RazonSocial = null,
    int NumeroPagina = 1,
    int TamanioPagina = 10
) : IRequest<PageResult<ClienteDto>>;
