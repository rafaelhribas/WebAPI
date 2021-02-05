using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Validators;

namespace WebAPI.Models
{
	public class Conta
	{
		public bool Calcular()
		{
			try
			{
				DiasAtraso = Convert.ToInt32((DataPagamento - DataVencimento).TotalDays);

				if (DiasAtraso >= 1 && DiasAtraso <= 3)
				{
					Multa = 2;
					JurosDia = 0.1M;
				}
				else if (DiasAtraso > 3 && DiasAtraso <= 5)
				{
					Multa = 3;
					JurosDia = 0.2M;
				}
				else if (DiasAtraso > 5)
				{
					Multa = 5;
					JurosDia = 0.3M;
				}

				if (Multa > 0 && JurosDia > 0)
				{
					var valorMulta = ValorOriginal + (ValorOriginal * (Multa / 100));
					var valorJurosDia = valorMulta + (JurosDia * DiasAtraso);
					ValorFinal = valorMulta + valorJurosDia;
				}
				else
				{
					ValorFinal = ValorOriginal;
				}

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool IsValid()
		{
			var contaValidator = new ContaValidator();
			return contaValidator.Validate(this).IsValid;
		}

		public string Errors()
		{
			var contaValidator = new ContaValidator();
			return contaValidator.Validate(this).ToString();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ContaId { get; set; }

		public string Nome { get; set; }

		[Column(TypeName = "decimal(18,4)")]
		public decimal ValorOriginal { get; set; }

		[Column(TypeName = "decimal(18,4)")]
		public decimal ValorFinal { get; set; }

		public DateTime DataVencimento { get; set; }

		public DateTime DataPagamento { get; set; }

		public int DiasAtraso { get; set; }

		[Column(TypeName = "decimal(18,4)")]
		public decimal Multa { get; set; }

		[Column(TypeName = "decimal(18,4)")]
		public decimal JurosDia { get; set; }
	}
}
