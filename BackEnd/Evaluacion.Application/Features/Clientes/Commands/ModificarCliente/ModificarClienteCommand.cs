using MediatR;

namespace Evaluacion.Application.Features.Clientes.Commands.ModificarCliente
{
    public class ModificarClienteCommand
        :IRequest<bool>
    {
        public ModificarClienteCommand(
            int id,
            ModificarClienteRequest request
            )
        {
            Id = id;
            Ruc = request.Ruc;
            RazonSocial = request.RazonSocial;
            TelefonoContacto = request.TelefonoContacto;
            CorreoContacto = request.CorreoContacto;
            Direccion = request.Direccion;
        }
        public int Id { get; }
        public string Ruc { get; }
        public string RazonSocial { get; }
        public string TelefonoContacto { get; }
        public string CorreoContacto { get; }
        public string Direccion { get; }
    }
}
