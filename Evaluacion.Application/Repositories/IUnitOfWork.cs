using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);
        Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken ct = default);
        public interface IUnitOfWorkTransaction : IAsyncDisposable
        {
            Task CommitAsync(CancellationToken ct = default);
            Task RollbackAsync(CancellationToken ct = default);
        }
    }
}
