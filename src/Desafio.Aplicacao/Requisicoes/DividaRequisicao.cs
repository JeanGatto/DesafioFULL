using Desafio.Aplicacao.Requisicoes.Comum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Aplicacao.Requisicoes
{
    public class DividaRequisicao : RequisicaoBase
    {
        [Required]
        [DataType(DataType.Text)]
        public string Numero { get; set; }

        [Required]
        public decimal Multa { get; set; }

        [Required]
        public decimal JurosAoMes { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string NomeCompleto { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CPF { get; set; }

        [Required]
        public IEnumerable<ParcelaRequisicao> Parcelas { get; set; }

        public override void Validar()
        {
            AdicionarNotificacoes(new DividaRequisicaoValidador().Validate(this));
        }
    }
}
