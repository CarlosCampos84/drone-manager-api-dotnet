using GSDrones.Models;
using GSDrones.Models.Enums;

namespace GSDrones.DTOs
{
    public class DroneResponseDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public TipoDrone Tipo { get; set; }
        public double CapacidadeKg { get; set; }
        public static DroneResponseDTO mapper(Drone drone) {
            return new DroneResponseDTO
            {
                Id = drone.Id,
                Nome = drone.Nome,
                Tipo = drone.Tipo,
                CapacidadeKg = drone.CapacidadeKg
            };
        }
    }

}