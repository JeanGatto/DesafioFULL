using Desafio.Dominio.Entidades;
using Desafio.Infraestrutura.Mapeamentos.Comum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infraestrutura.Mapeamentos
{
    public class DevedorMapeamento : EntidadeBaseMapeamento<Devedor>
    {
        public override void Configure(EntityTypeBuilder<Devedor> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Devedor));

            builder.Property(devedor => devedor.NomeCompleto)
                .IsRequired()
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100);

            builder.Property(devedor => devedor.CPF)
                .IsRequired()
                .HasColumnType("VARCHAR(11)")
                .HasMaxLength(11);
        }
    }
}
