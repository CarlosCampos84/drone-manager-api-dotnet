using GSDrones.Models;
using GSDrones.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSDrones.Data.Migrations
{
    public class MissaoMapping : IEntityTypeConfiguration<Missao>
    {
        public void Configure(EntityTypeBuilder<Missao> builder)
        {
            builder.ToTable("t_gs_missoes");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Descricao)
                .HasColumnName("ds_missao")
                .HasColumnType("VARCHAR(500)")
                .IsRequired();

            builder.Property(m => m.DataInicio)
                .HasColumnName("dt_inicio")
                .IsRequired();

            builder.Property(m => m.DataFim)
                .HasColumnName("dt_fim");

            var maxEnumLength = Enum.GetNames(typeof(StatusMissao)).Max(n => n.Length);
            builder.Property(m => m.Status)
                .HasColumnName("st_missao")
                .HasConversion<string>()
                .HasMaxLength(maxEnumLength)
                .IsRequired();

            builder.Property(m => m.PesoTotal)
                .HasColumnName("nr_peso_total")
                .IsRequired();

            builder.Property(m => m.DroneId)
                .HasColumnName("drone_id")
                .IsRequired();

            builder.HasOne(m => m.Drone)
                .WithMany(d => d.Missoes)
                .HasForeignKey(m => m.DroneId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Suprimentos)
                .WithOne(sm => sm.Missao)
                .HasForeignKey(sm => sm.MissaoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}