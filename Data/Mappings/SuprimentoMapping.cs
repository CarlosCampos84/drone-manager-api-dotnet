using GSDrones.Models;
using GSDrones.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSDrones.Data.Migrations
{
    public class SuprimentoMapping : IEntityTypeConfiguration<Suprimento>
    {
        public void Configure(EntityTypeBuilder<Suprimento> builder)
        {
            builder.ToTable("t_gs_suprimentos");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome)
                .HasColumnName("nm_suprimento")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(s => s.Descricao)
                .HasColumnName("ds_suprimento")
                .HasColumnType("VARCHAR(500)")
                .IsRequired();

            builder.Property(s => s.PesoKg)
                .HasColumnName("peso_kg")
                .IsRequired();

            builder.HasMany(s => s.Missoes)
                .WithOne(sm => sm.Suprimento)
                .HasForeignKey(sm => sm.SuprimentoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}