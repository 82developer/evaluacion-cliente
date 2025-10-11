using AutoMapper;
using Evaluacion.Domain;

namespace Evaluacion.Application.Features.Clientes.Commands.ModificarCliente
{
    public class ModificarClienteProfile:Profile
    {
        public ModificarClienteProfile()
        {
            CreateMap<ModificarClienteCommand,Cliente>();
        }
    }
}
