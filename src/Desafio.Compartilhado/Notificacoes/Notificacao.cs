namespace Desafio.Compartilhado.Notificacoes
{
    public sealed class Notificacao
    {
        public Notificacao(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public string Propriedade { get; }
        public string Mensagem { get; }

        public override string ToString()
        {
            return $"{Propriedade}: {Mensagem}";
        }
    }
}