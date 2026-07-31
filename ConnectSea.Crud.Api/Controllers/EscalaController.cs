using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace ConnectSea.Crud.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscalaController : ControllerBase
    {
        private readonly IEscalaService _service;

        public EscalaController(IEscalaService service)
        {
            _service = service;
        }      

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var result = await _service.GetAllPagedAsync(page, size);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("por-manifesto/{id}")]
        public async Task<IActionResult> GetEscalasByManifestoId(int id)
        {
            var result = await _service.GetEscalasByManifestoId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EscalaCommand command)
        {
            await _service.CreateAsync(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EscalaCommand command)
        {
            await _service.UpdateAsync(id, command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}