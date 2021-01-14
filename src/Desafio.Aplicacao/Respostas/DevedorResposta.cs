using Desafio.Aplicacao.Respostas.Comum;

namespace Desafio.Aplicacao.Respostas
{
    public class DevedorResposta : RespostaBase
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
    }
}
