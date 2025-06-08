using GSDrones.DTOs;
using GSDrones.Services;
using Microsoft.AspNetCore.Mvc;

namespace GSDrones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissaoController : ControllerBase
    {
        private readonly MissaoService _service;

        public MissaoController(MissaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MissaoResponseDTO>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<MissaoResponseDTO>> GetById(long id)
        {
            MissaoResponseDTO? missao = await _service.GetByIdAsync(id);
            if (missao == null) return NotFound();
            return Ok(missao);
        }

        [HttpPost]
        public async Task<ActionResult<MissaoResponseDTO>> Create([FromBody] MissaoRequestDTO dto)
        {
            var (created, error) = await _service.CreateAsync(dto);
            if (error != null) return BadRequest(error);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}/concluir")]
        public async Task<IActionResult> Concluir(long id)
        {
            bool ok = await _service.PatchConcluirAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancelar(long id)
        {
            bool ok = await _service.DeleteCancelarAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}