using Desafio.Compartilhado.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infraestrutura.Compartilhado.Mapeamentos
{
    public abstract class EntidadeBaseMapeamento<TEntidade> : IEntityTypeConfiguration<TEntidade>
        where TEntidade : EntidadeBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            // Definindo a coluna "ID" como Chave Primária (PK).
            builder.HasKey(entidade => entidade.Id);

            // Definindo a coluna "ID" como NOT NULL e IDENTITY.
            builder.Property(entidade => entidade.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(entidade => entidade.CadastradoEm)
                .IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
