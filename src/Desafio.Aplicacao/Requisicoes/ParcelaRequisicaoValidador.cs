using FluentValidation;

namespace Desafio.Aplicacao.Requisicoes
{
    public class ParcelaRequisicaoValidador : AbstractValidator<ParcelaRequisicao>
    {
        public ParcelaRequisicaoValidador()
        {
            RuleFor(p => p.Numero)
                .NotEmpty();

            RuleFor(p => p.Valor)
                .NotEmpty();

            RuleFor(p => p.DataVencimento)
                .NotEmpty();
        }
    }
}