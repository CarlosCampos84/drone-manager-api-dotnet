using GSDrones.Models;
using GSDrones.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSDrones.Data.Migrations
{
    public class DroneMapping : IEntityTypeConfiguration<Drone>
    {
        public void Configure(EntityTypeBuilder<Drone> builder)
        {
            builder.ToTable("t_gs_drones");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Nome)
                .HasColumnName("nm_drone")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            var maxEnumLength = Enum.GetNames(typeof(TipoDrone)).Max(n => n.Length);
            builder.Property(d => d.Tipo)
                .HasColumnName("tp_drone")
                .HasConversion<string>()
                .HasMaxLength(maxEnumLength)
                .IsRequired();

            builder.Property(d => d.CapacidadeKg)
                .HasColumnName("nr_capacidade_kg")
                .IsRequired();

            builder.HasMany(d => d.Missoes)
                .WithOne(m => m.Drone)
                .HasForeignKey(m => m.DroneId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}