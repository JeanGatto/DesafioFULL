using Desafio.Compartilhado.Entidades;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.Compartilhado.Interfaces
{
    public interface IRepositorioBase<TEntidade> : IDisposable
        where TEntidade : EntidadeBase, IRaizAgregacao
    {
        void Adicionar(TEntidade entidade);
        Task<IEnumerable<TEntidade>> ListarAsync();
        Task<TEntidade> ObterPorIdAsync(int id);
        Task<int> SalvarAlteracoesAsync(CancellationToken cancellationToken = default);
    }
}