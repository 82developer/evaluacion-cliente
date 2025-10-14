using Evaluacion.Application.Dtos;
using MediatR;

namespace Evaluacion.Application.Features.Clientes.Queries.BuscarPorIdCliente;
public sealed record BuscarPorIdClienteQuery(int Id) : IRequest<ClienteDto>;
