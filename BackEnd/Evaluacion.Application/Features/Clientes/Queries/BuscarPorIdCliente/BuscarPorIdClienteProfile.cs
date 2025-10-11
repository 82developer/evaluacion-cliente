using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Features.Clientes.Queries.BuscarPorIdCliente
{
    public class BuscarPorIdClienteProfile:Profile
    {
        public BuscarPorIdClienteProfile()
        {
           CreateMap<Domain.Cliente, Dtos.ClienteDto>(); 
        }
    }
}
