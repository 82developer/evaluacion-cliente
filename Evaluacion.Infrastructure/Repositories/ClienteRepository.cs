using Evaluacion.Application.Repositories;
using Evaluacion.Domain;
using Evaluacion.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> ActualizarAsync(Cliente cliente)
        {
            var existing = await _db.Users.FirstOrDefaultAsync(c => c.Id == cliente.Id);

            existing.Ruc = cliente.Ruc;
            existing.RazonSocial = cliente.RazonSocial;
            existing.Telefono = cliente.Telefono;
            existing.Correo = cliente.Correo;

            _db.Users.Update(existing);
            //await _db.SaveChangesAsync();
            return true;
        }

        public async Task<int> CrearAsync(Cliente cliente)
        {
            await _db.Users.AddAsync(cliente);
            //await _db.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var cliente = await _db.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
                return false;

            _db.Users.Remove(cliente);
            //await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            var result = await _db.Users
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
