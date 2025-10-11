using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Application.Features.Clientes.Queries.BuscarPorIdCliente
{
    public class BuscarPorIdClienteQueryValidate
                 : AbstractValidator<BuscarPorIdClienteQuery>
    {
        public BuscarPorIdClienteQueryValidate()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0)
                .WithMessage("El Id es requerido.");
        }
    }
}
