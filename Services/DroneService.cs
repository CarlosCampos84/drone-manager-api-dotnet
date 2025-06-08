using GSDrones.DTOs;
using GSDrones.Models;
using GSDrones.Models.Enums;
using GSDrones.Repositories;

namespace GSDrones.Services
{
    public class DroneService
    {
        private readonly DroneRepository _repository;
        public DroneService(DroneRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DroneResponseDTO>> GetAllAsync()
        {
            List<Drone> drones = await _repository.GetAllAsync();
            return drones.Select(DroneResponseDTO.mapper).ToList();
        }

        public async Task<Drone?> GetByIdAsync(long id)
        {
            Drone? d = await _repository.GetByIdAsync(id);
            if (d == null) return null;
            return d;
        }

        public async Task<DroneResponseDTO> CreateAsync(DroneRequestDTO dto)
        {
            TipoDrone tipoDrone = Enum.Parse<TipoDrone>(dto.Tipo, true);
            Drone drone = new Drone
            {
                Nome = dto.Nome,
                Tipo = tipoDrone,
                CapacidadeKg = dto.CapacidadeKg
            };
            await _repository.AddAsync(drone);
            return DroneResponseDTO.mapper(drone);
        }

        public async Task<bool> UpdateAsync(long id, DroneRequestDTO dto)
        {
            Drone? drone = await _repository.GetByIdAsync(id);
            TipoDrone tipoDrone = Enum.Parse<TipoDrone>(dto.Tipo, true);
            if (drone == null) return false;
            drone.Nome = dto.Nome;
            drone.Tipo = tipoDrone;
            drone.CapacidadeKg = dto.CapacidadeKg;
            await _repository.UpdateAsync(drone);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            Drone? drone = await _repository.GetByIdAsync(id);
            if (drone == null) return false;
            await _repository.DeleteAsync(drone);
            return true;
        }
    }
}