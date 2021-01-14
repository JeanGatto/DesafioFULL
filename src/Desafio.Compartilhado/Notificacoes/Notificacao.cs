namespace Desafio.Compartilhado.Notificacoes
{
    public class Notificacao
    {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public Notificacao(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public string Propriedade { get; }
        public string Mensagem { get; }
    }
}