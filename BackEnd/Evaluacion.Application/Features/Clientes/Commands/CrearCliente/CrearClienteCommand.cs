using MediatR;

namespace Evaluacion.Application.Features.Clientes.Commands.CrearCliente;

public sealed record CrearClienteCommand(
    string Ruc,
    string RazonSocial,
    string TelefonoContacto,
    string CorreoContacto,
    string? Direccion
) : IRequest<int>;
