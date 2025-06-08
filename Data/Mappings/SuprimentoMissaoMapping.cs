using GSDrones.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSDrones.Data.Migrations
{
    public class SuprimentoMissaoMapping : IEntityTypeConfiguration<SuprimentoMissao>
    {
        public void Configure(EntityTypeBuilder<SuprimentoMissao> builder)
        {
            builder.ToTable("t_gs_suprimentos_missao");

            builder.HasKey(sm => sm.Id);

            builder.Property(sm => sm.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(sm => sm.MissaoId)
                .HasColumnName("missao_id")
                .IsRequired();

            builder.Property(sm => sm.SuprimentoId)
                .HasColumnName("suprimento_id")
                .IsRequired();

            builder.Property(sm => sm.Quantidade)
                .HasColumnName("qt_suprimento")
                .IsRequired();

            builder.HasOne(sm => sm.Missao)
                .WithMany(m => m.Suprimentos)
                .HasForeignKey(sm => sm.MissaoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sm => sm.Suprimento)
                .WithMany(s => s.Missoes)
                .HasForeignKey(sm => sm.SuprimentoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}