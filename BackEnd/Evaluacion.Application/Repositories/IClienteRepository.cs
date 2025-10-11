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
        Task<List<Cliente>> ObtenerTodosAsync(int pagina, int tamanoPagina);
    }
}
