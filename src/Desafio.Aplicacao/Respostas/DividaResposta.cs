using Desafio.Aplicacao.Respostas.Comum;
using System;
using System.Collections.Generic;

namespace Desafio.Aplicacao.Respostas
{
    public class DividaResposta : RespostaBase
    {
        public long Id { get; set; }
        public string Numero { get; set; }
        public decimal Multa { get; set; }
        public decimal JurosAoMes { get; set; }
        public int QuantidadeParcelas { get; set; }
        public int DiasEmAtraso { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal TotalMulta { get; set; }
        public decimal TotalJurosDataHoje { get; set; }
        public decimal ValorAtualizadoDataHoje { get; set; }
        public DateTime CadastradoEm { get; set; }

        public DevedorResposta Devedor { get; set; }
        public IEnumerable<ParcelaResposta> Parcelas { get; set; }
    }
}
