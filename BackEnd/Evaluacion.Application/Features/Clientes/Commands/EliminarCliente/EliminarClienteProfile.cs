using AutoMapper;
using Evaluacion.Domain;

namespace Evaluacion.Application.Features.Clientes.Commands.EliminarCliente
{
    public class EliminarClienteProfile:Profile
    {
        public EliminarClienteProfile()
        {
           CreateMap<EliminarClienteCommand,Cliente>(); 
        }
    }
}
