using Evaluacion.Application.Features.Clientes.Commands.CrearCliente;
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
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] CrearClienteCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CrearClienteCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpGet]
        public async Task<IActionResult> GetOne([FromBody] CrearClienteCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpGet("page")]
        public async Task<IActionResult> GetPage([FromBody] CrearClienteCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

    }
}
