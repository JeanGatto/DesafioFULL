using Desafio.Dominio.Entidades;
using Desafio.Infraestrutura.Mapeamentos.Comum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infraestrutura.Mapeamentos
{
    public class DividaMapeamento : EntidadeBaseMapeamento<Divida>
    {
        public override void Configure(EntityTypeBuilder<Divida> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Divida));

            builder.Property(divida => divida.Numero)
                .IsRequired()
                .HasColumnType("VARCHAR(10)")
                .HasMaxLength(10);

            builder.HasIndex(divida => divida.Numero);

            builder.Property(divida => divida.Multa)
                .IsRequired()
                .HasColumnType("NUMERIC(10,2)")
                .HasPrecision(10, 2);

            builder.Property(divida => divida.JurosAoMes)
                .IsRequired()
                .HasColumnType("NUMERIC(10,2)")
                .HasPrecision(10, 2);

            builder.Navigation(divida => divida.Parcelas)
                .HasField("_parcelas");

            builder.HasOne(divida => divida.Devedor)
                .WithMany(devedor => devedor.Dividas)
                .HasForeignKey(divida => divida.DevedorId)
                .OnDelete(DeleteBehavior.Restrict);

            #region Propriedades Ignoradas

            builder.Ignore(divida => divida.QuantidadeParcelas);
            builder.Ignore(divida => divida.DiasEmAtraso);
            builder.Ignore(divida => divida.ValorOriginal);
            builder.Ignore(divida => divida.TotalMulta);
            builder.Ignore(divida => divida.TotalJurosDataHoje);
            builder.Ignore(divida => divida.ValorAtualizadoDataHoje);

            #endregion
        }
    }
}