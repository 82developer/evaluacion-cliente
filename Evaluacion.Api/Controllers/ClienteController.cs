using Evaluacion.Application.Features.Clientes.Commands.CrearCliente;
using Evaluacion.Application.Features.Clientes.Commands.EliminarCliente;
using Evaluacion.Application.Features.Clientes.Commands.ModificarCliente;
using Evaluacion.Application.Features.Clientes.Queries.BuscarPaginadoCliente;
using Evaluacion.Application.Features.Clientes.Queries.BuscarPorIdCliente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearClienteCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] ModificarClienteRequest request
            )
        {
            var result = await _mediator.Send(new ModificarClienteCommand(id, request));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new EliminarClienteCommand(id));
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var response = await _mediator.Send(new BuscarPorIdClienteQuery(id));
            return Ok(response);
        }
        [HttpGet("page")]
        public async Task<IActionResult> GetPage([FromBody] BuscarPaginadoClienteQuery query)
        {
            var id = await _mediator.Send(query);
            return Ok(id);
        }

    }
}
