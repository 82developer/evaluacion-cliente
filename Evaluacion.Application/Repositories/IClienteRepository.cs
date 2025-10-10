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
        int Crear(Cliente cliente);
        int Actualizar(Cliente cliente);
        int Eliminar(int id);
        Cliente ObtenerPorId(int id);
        List<Cliente> ObtenerTodos(int pagina, int tamanoPagina);
    }
}
