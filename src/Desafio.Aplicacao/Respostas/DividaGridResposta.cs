using Desafio.Aplicacao.Respostas.Comum;
using System;

namespace Desafio.Aplicacao.Respostas
{
    public class DividaGridResposta : RespostaBase
    {
        public long Id { get; set; }
        public string Numero { get; set; }
        public decimal Multa { get; set; }
        public decimal JurosAoMes { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public DateTime CadastradoEm { get; set; }
    }
}
