using FluentValidation;
using WebAPI.Models;

namespace WebAPI.Validators
{
	public class ContaValidator : AbstractValidator<Conta>
	{
		public ContaValidator()
		{
			RuleFor(c=>c.Nome).NotEmpty().WithMessage("Nome da conta é obrigatório");
			RuleFor(c => c.ValorOriginal).NotNull().GreaterThan(0).WithMessage("Valor da conta é obrigatório");
			RuleFor(c => c.DataVencimento).NotNull().NotEmpty().WithMessage("Data vencimento da conta é obrigatório");
			RuleFor(c => c.DataPagamento).NotNull().NotEmpty().WithMessage("Data de pagamento da conta é obrigatório");
		}
	}
}
