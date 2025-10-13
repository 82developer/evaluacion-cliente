using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Dtos
{
    public sealed class PageResult<T>
    {
        public IReadOnlyList<T> Items { get; set; }
        public int TotalCount { get; set; }

        // convenience
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
