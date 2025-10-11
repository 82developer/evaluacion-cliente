namespace Evaluacion.Application.Features.Clientes.Commands.ModificarCliente
{
    public class ModificarClienteCommand
    {
        public ModificarClienteCommand(
            int id,
            ModificarClienteRequest request
            )
        {
            Id = id;
            Ruc = request.Ruc;
            RazonSocial = request.RazonSocial;
            Telefono = request.Telefono;
            Correo = request.Correo;
            Direccion = request.Direccion;
        }
        public int Id { get; }
        public string Ruc { get; }
        public string RazonSocial { get; }
        public string Telefono { get; }
        public string Correo { get; }
        public string Direccion { get; }
    }
}
