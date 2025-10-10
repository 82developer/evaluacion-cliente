namespace Evaluacion.Application.Features.Clientes.Commands.ModificarCliente
{
    public class ModificarClienteCommand
    {

        public int Id { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
