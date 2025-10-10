using Evaluacion.Application.Repositories;
using Evaluacion.Domain;
using Evaluacion.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Infrastructure.Repositories
{
    public class ClienteRepository
        : IClienteRepository
    {
        private readonly ApplicationDbContext _db;
        public ClienteRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Actualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public int Crear(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObtenerTodos(int pagina, int tamanoPagina)
        {
            throw new NotImplementedException();
        }
    }
}
