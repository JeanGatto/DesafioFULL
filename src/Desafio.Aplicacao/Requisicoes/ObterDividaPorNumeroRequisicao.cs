using Desafio.Aplicacao.Requisicoes.Comum;
using FluentValidation;

namespace Desafio.Aplicacao.Requisicoes
{
    public class ObterDividaPorNumeroRequisicao : RequisicaoBase
    {
        public ObterDividaPorNumeroRequisicao(string numero)
        {
            Numero = numero;
        }

        public string Numero { get; }

        public override void Validar()
        {
            var validador = new InlineValidator<ObterDividaPorNumeroRequisicao>();
            validador.RuleFor(x => x.Numero).NotEmpty().MaximumLength(10);
            AdicionarNotificacoes(validador.Validate(this));
        }
    }
}