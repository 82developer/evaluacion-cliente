using Evaluacion.Application.Dtos;
using Evaluacion.Application.Features.Clientes.Queries.BuscarPaginadoCliente;
using Evaluacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Repositories
{
    public interface IClienteRepository
    {
        Task<int> CrearAsync(Cliente cliente);
        Task<bool> ActualizarAsync(Cliente cliente);
        Task<bool> EliminarAsync(int id);
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task<PageResult<ClienteDto>> ObtenerTodosAsync(
            string ruc,
            string razonSocial,
            int numeroPagina,
            int tamanioPagina
            );
    }
}
