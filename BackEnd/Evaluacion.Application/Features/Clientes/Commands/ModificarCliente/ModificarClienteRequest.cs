using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Features.Clientes.Commands.ModificarCliente
{
    public class ModificarClienteRequest
    {
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string TelefonoContacto { get; set; }
        public string CorreoContacto { get; set; }
        public string? Direccion { get; set; }
    }
}
