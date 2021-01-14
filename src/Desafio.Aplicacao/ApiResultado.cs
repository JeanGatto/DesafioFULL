using Desafio.Aplicacao.Respostas.Comum;
using Desafio.Compartilhado.Notificacoes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Aplicacao
{
    public class ApiResultado<T> where T : RespostaBase
    {
        public ApiResultado()
        {
            Erros = Enumerable.Empty<Notificacao>();
        }

        [JsonProperty(Order = 0)]
        public string Mensagem { get; private set; }

        [JsonProperty(Order = 1)]
        public bool BemSucedido { get; private set; }

        [JsonIgnore]
        public bool RecursoNaoEncontrado { get; private set; }

        [JsonProperty(Order = 2)]
        public IEnumerable<Notificacao> Erros { get; private set; }

        [JsonProperty(Order = 3, Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public T Dados { get; private set; }

        public ApiResultado<T> Falha(string mensagem)
        {
            BemSucedido = false;
            Mensagem = mensagem;
            return this;
        }

        public ApiResultado<T> Falha(string mensagem, bool recursoNaoEncontrado)
        {
            BemSucedido = false;
            Mensagem = mensagem;
            RecursoNaoEncontrado = recursoNaoEncontrado;
            return this;
        }

        public ApiResultado<T> Falha(IEnumerable<Notificacao> notificacoes)
        {
            BemSucedido = false;
            Mensagem = "Requisição inválida.";
            Erros = notificacoes;
            return this;
        }

        public ApiResultado<T> Sucesso(T dados)
        {
            BemSucedido = true;
            Dados = dados;
            return this;
        }

        public ApiResultado<T> Sucesso(string mensagem, T dados)
        {
            BemSucedido = true;
            Mensagem = mensagem;
            Dados = dados;
            return this;
        }
    }
}