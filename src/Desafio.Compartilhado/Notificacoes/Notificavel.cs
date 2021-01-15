using FluentValidation.Results;
using System.Collections.Generic;

namespace Desafio.Compartilhado.Notificacoes
{
    public abstract class Notificavel
    {
        private readonly List<Notificacao> _notificacoes;

        protected Notificavel()
        {
            _notificacoes = new List<Notificacao>();
        }

        public bool Invalido => _notificacoes.Count > 0;
        public IReadOnlyList<Notificacao> Notificacoes => _notificacoes.AsReadOnly();

        public void AdicionarNotificacao(string mensagem)
        {
            _notificacoes.Add(new Notificacao(string.Empty, mensagem));
        }

        public void AdicionarNotificacao(string propriedade, string mensagem)
        {
            _notificacoes.Add(new Notificacao(propriedade, mensagem));
        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public void AdicionarNotificacoes(ValidationResult resultadoValidacao)
        {
            if (resultadoValidacao.IsValid) return;

            foreach (var falha in resultadoValidacao.Errors)
            {
                _notificacoes.Add(new Notificacao(falha.PropertyName, falha.ErrorMessage));
            }
        }

        public void AdicionarNotificacoes(IEnumerable<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }

        public void Limpar()
        {
            _notificacoes.Clear();
        }
    }
}