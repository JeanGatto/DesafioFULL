using Desafio.Aplicacao.Respostas.Comum;
using System;

namespace Desafio.Aplicacao.Respostas
{
    public class ParcelaResposta : RespostaBase
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public DateTime CadastradoEm { get; set; }
    }
}