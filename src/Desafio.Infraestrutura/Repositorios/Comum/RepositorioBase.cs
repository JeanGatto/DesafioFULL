using Desafio.Compartilhado.Entidades;
using Desafio.Compartilhado.Interfaces;
using Desafio.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.Infraestrutura.Repositorios.Comum
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase, IRaizAgregacao
    {
        protected readonly DbSet<TEntidade> DbSet;
        private readonly DesafioContexto _contexto;

        protected RepositorioBase(DesafioContexto contexto)
        {
            _contexto = contexto;
            DbSet = contexto.Set<TEntidade>();
        }

        public void Adicionar(TEntidade entidade)
        {
            DbSet.Add(entidade);
        }

        public virtual async Task<IEnumerable<TEntidade>> ListarAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntidade> ObterPorIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public Task<int> SalvarAlteracoesAsync(CancellationToken cancellationToken = default)
        {
            return _contexto.SaveChangesAsync(cancellationToken);
        }

        #region Dispose

        // Flag: Has Dispose already been called?
        private bool _disposed = false;

        ~RepositorioBase()
        {
            Dispose(false);
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free any other managed objects here.
                _contexto.Dispose();
            }

            // Free any unmanaged objects here.
            _disposed = true;
        }

        #endregion
    }
}