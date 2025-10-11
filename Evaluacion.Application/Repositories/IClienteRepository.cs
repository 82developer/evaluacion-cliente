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
        Task<int> Crear(Cliente cliente);
        Task<int> Actualizar(Cliente cliente);
        Task<int> Eliminar(int id);
        Task<Cliente> ObtenerPorId(int id);
        Task<List<Cliente>> ObtenerTodos(int pagina, int tamanoPagina);
    }
}
