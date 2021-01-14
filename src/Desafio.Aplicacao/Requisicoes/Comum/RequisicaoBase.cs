using Desafio.Compartilhado.Notificacoes;

namespace Desafio.Aplicacao.Requisicoes.Comum
{
    /// <summary>
    /// Classe base usada pelas requisições da API.
    /// </summary>
    public abstract class RequisicaoBase : Notificavel
    {
        /// <summary>
        /// Valida a requisição.
        /// </summary>
        public abstract void Validar();
    }
}