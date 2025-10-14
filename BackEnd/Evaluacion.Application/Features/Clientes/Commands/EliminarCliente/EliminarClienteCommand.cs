using MediatR;

namespace Evaluacion.Application.Features.Clientes.Commands.EliminarCliente;
public sealed record EliminarClienteCommand(int Id) : IRequest<bool>;
