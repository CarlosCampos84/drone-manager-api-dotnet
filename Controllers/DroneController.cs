using GSDrones.DTOs;
using GSDrones.Models;
using GSDrones.Services;
using Microsoft.AspNetCore.Mvc;

namespace GSDrones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DroneController : ControllerBase
    {
        private readonly DroneService _service;
        public DroneController(DroneService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<DroneResponseDTO>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<DroneResponseDTO>> GetById(long id)
        {
            Drone? drone = await _service.GetByIdAsync(id);
            if (drone == null) return NotFound();
            return Ok(DroneResponseDTO.mapper(drone));
        }

        [HttpPost]
        public async Task<ActionResult<DroneResponseDTO>> Create(DroneRequestDTO dto)
        {
            DroneResponseDTO created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, DroneRequestDTO dto)
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