using Desafio.Dominio.Entidades;
using Desafio.Infraestrutura.Mapeamentos.Comum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infraestrutura.Mapeamentos
{
    public class ParcelaMapeamento : EntidadeBaseMapeamento<Parcela>
    {
        public override void Configure(EntityTypeBuilder<Parcela> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Parcela));

            builder.Property(parcela => parcela.Numero)
                .IsRequired();

            builder.Property(parcela => parcela.DataVencimento)
                .IsRequired()
                .HasColumnType("DATE");

            builder.Property(parcela => parcela.Valor)
                .IsRequired()
                .HasColumnType("NUMERIC(10,2)")
                .HasPrecision(10, 2);

            builder.HasOne(parcela => parcela.Divida)
                .WithMany(divida => divida.Parcelas)
                .HasForeignKey(parcela => parcela.DividaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
