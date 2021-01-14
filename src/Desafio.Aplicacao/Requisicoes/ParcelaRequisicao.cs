using Desafio.Aplicacao.Requisicoes.Comum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Aplicacao.Requisicoes
{
    public class ParcelaRequisicao : RequisicaoBase
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        public override void Validar()
        {
            AdicionarNotificacoes(new ParcelaRequisicaoValidador().Validate(this));
        }
    }
}
