using Desafio.Aplicacao.Requisicoes;
using Desafio.Aplicacao.Respostas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Aplicacao.Interfaces
{
    public interface IDividaServico : IDisposable
    {
        Task<ApiResultado<DividaResposta>> CriarAsync(DividaRequisicao requisicao);
        Task<IEnumerable<DividaGridResposta>> ListarAsync();
        Task<ApiResultado<DividaResposta>> ObterPorIdAsync(int id);
        Task<ApiResultado<DividaResposta>> ObterPorNumeroAsync(ObterDividaPorNumeroRequisicao requisicao);
    }
}
