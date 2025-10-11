using Evaluacion.Application.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Evaluacion.Application.Repositories.IUnitOfWork;

namespace Evaluacion.Infrastructure.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);

        public async Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken ct = default)
        {
            var tx = await _db.Database.BeginTransactionAsync(ct);
            return new EfCoreUnitOfWorkTransaction(tx);
        }

        public ValueTask DisposeAsync() => _db.DisposeAsync();

        private sealed class EfCoreUnitOfWorkTransaction : IUnitOfWorkTransaction
        {
            private readonly IDbContextTransaction _tx;

            public EfCoreUnitOfWorkTransaction(IDbContextTransaction tx)
            {
                _tx = tx;
            }

            public Task CommitAsync(CancellationToken ct = default)
                => _tx.CommitAsync(ct);

            public Task RollbackAsync(CancellationToken ct = default)
                => _tx.RollbackAsync(ct);

            public ValueTask DisposeAsync() => _tx.DisposeAsync();
        }
    }
}

