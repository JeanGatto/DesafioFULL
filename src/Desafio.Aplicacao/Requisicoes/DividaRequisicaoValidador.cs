using FluentValidation;

namespace Desafio.Aplicacao.Requisicoes
{
    public class DividaRequisicaoValidador : AbstractValidator<DividaRequisicao>
    {
        public DividaRequisicaoValidador()
        {
            RuleFor(d => d.Numero)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(d => d.Multa)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(d => d.JurosAoMes)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(d => d.NomeCompleto)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(d => d.CPF)
                .NotEmpty()
                .MinimumLength(11) // Sem Máscara
                .MaximumLength(14) // Com Máscara
                .IsValidCPF();

            RuleFor(d => d.Parcelas)
                .NotEmpty()
                .WithMessage("É necessário informar ao menos uma parcela.");

            RuleForEach(d => d.Parcelas)
                .SetValidator(new ParcelaRequisicaoValidador());
        }
    }
}