using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using ListaTelefonica.APIAna.Models;
using ListaTelefonica.APIAna.Application.Contatos.Commands;
using ListaTelefonica.APIAna.Application.Contatos.Queries;

namespace ListaTelefonica.APIAna.Controllers
{
    [ApiController]
    [Route("contatos")]
    public class ContatosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContatosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllContatosQuery());
            return Ok(result);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Contato>> GetById(string id)
        {
            var result = await _mediator.Send(new GetContatoByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Contato>> Create([FromBody] CreateContatoCommand command)
        {
            if (command == null) return BadRequest();
            var created = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<Contato>> Update(string id, [FromBody] UpdateContatoCommand command)
        {
            if (command == null || id != command.Id) return BadRequest();
            var updated = await _mediator.Send(command);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpPatch("{id:length(24)}")]
        public async Task<ActionResult<Contato>> Patch(string id, [FromBody] UpdateContatoCommand command)
        {
            if (command == null || id != command.Id) return BadRequest();
            var updated = await _mediator.Send(command);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> Delete(string id)
        {
            var deleted = await _mediator.Send(new DeleteContatoCommand { Id = id });
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
