using MediatR;

namespace Evaluacion.Application.Features.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommand: IRequest<int>
    {
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string TelefonoContacto { get; set; }
        public string CorreoContacto { get; set; }
        public string Direccion { get; set; }
    }
}
