using Desafio.Aplicacao.Requisicoes.Comum;
using System.Collections.Generic;

namespace Desafio.Aplicacao.Requisicoes
{
    public class DividaRequisicao : RequisicaoBase
    {
        public string Numero { get; set; }
        public decimal Multa { get; set; }
        public decimal JurosAoMes { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }

        public IEnumerable<ParcelaRequisicao> Parcelas { get; set; }

        public override void Validar()
        {
            AdicionarNotificacoes(new DividaRequisicaoValidador().Validate(this));
        }
    }
}
