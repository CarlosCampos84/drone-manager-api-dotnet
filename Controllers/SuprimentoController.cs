using GSDrones.DTOs;
using GSDrones.Services;
using Microsoft.AspNetCore.Mvc;

namespace GSDrones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuprimentoController : ControllerBase
    {
        private readonly SuprimentoService _service;

        public SuprimentoController(SuprimentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuprimentoResponseDTO>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<SuprimentoResponseDTO>> GetById(long id)
        {
            SuprimentoResponseDTO? suprimento = await _service.GetByIdAsync(id);
            if (suprimento == null) return NotFound();
            return Ok(suprimento);
        }

        [HttpPost]
        public async Task<ActionResult<SuprimentoResponseDTO>> Create(SuprimentoRequestDTO dto)
        {
            SuprimentoResponseDTO created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, SuprimentoRequestDTO dto)
        {
            bool updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}