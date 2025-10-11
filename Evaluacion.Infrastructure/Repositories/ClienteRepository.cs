using Evaluacion.Application.Repositories;
using Evaluacion.Domain;
using Evaluacion.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> ActualizarAsync(Cliente cliente)
        {
            var entity = await _db.Clientes.FirstOrDefaultAsync(c => c.Id == cliente.Id);
            if(entity == null)
                return false;

            entity.Ruc = cliente.Ruc;
            entity.RazonSocial = cliente.RazonSocial;
            entity.Telefono = cliente.Telefono;
            entity.Correo = cliente.Correo;
            entity.Direccion = cliente.Direccion;

            _db.Clientes.Update(entity);
            return true;
        }

        public async Task<int> CrearAsync(Cliente cliente)
        {
            await _db.Clientes.AddAsync(cliente);
            return cliente.Id;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var cliente = await _db.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
                return false;

            _db.Clientes.Remove(cliente);
            return true;
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            var result = await _db.Clientes
                            .AsNoTracking()
                            .FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<List<Cliente>> ObtenerTodosAsync(int pagina, int tamanoPagina)
        {
            throw new NotImplementedException();
        }
    }
}
