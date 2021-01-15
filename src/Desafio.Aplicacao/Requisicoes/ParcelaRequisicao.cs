using Desafio.Aplicacao.Requisicoes.Comum;
using System;

namespace Desafio.Aplicacao.Requisicoes
{
    public class ParcelaRequisicao : RequisicaoBase
    {
        public int Numero { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }

        public override void Validar()
        {
            AdicionarNotificacoes(new ParcelaRequisicaoValidador().Validate(this));
        }
    }
}
