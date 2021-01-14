using Desafio.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Desafio.Infraestrutura.Contexto
{
    public class DesafioContexto : DbContext
    {
        public DesafioContexto(DbContextOptions<DesafioContexto> opcoes)
            : base(opcoes)
        {
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                base.ChangeTracker.LazyLoadingEnabled = false;
                return base.ChangeTracker;
            }
        }

        public DbSet<Divida> Dividas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Collation: define o conjunto de regras que o servidor irá utilizar para ordenação e comparação entre textos.
            // Configurado para ignorar o "Case Insensitive (CI)" e os acentos "Accent Insensitive (AI)".
            modelBuilder.UseCollation("Latin1_General_CI_AI");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
