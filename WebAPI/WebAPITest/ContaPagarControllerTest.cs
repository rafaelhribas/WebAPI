using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Models;
using Xunit;

namespace WebAPITest
{
	public class ContaPagarControllerTest
	{
		[Fact]
		public void GetContaPagar()
		{
			var options = new DbContextOptionsBuilder<ContaContext>()
				.UseInMemoryDatabase(databaseName: "WebAPI")
				.Options;

			using (var context = new ContaContext(options))
			{
				context.Add(new Conta
				{
					Nome = "Conta 01",
					ValorOriginal = 100,
					DataVencimento = Convert.ToDateTime("2021-01-01"),
					DataPagamento = Convert.ToDateTime("2021-01-20")
				});

				context.SaveChanges();
			}

			using (var context = new ContaContext(options))
			{
				ContaPagarController contaPagarController = new ContaPagarController(context);

				var result = contaPagarController.Get() as ObjectResult;

				var contas = Assert.IsType<List<Conta>>(result.Value);
				Assert.True(contas.Count > 0);
			}
		}

		[Fact]
		public void PostContaPagarValido()
		{
			var options = new DbContextOptionsBuilder<ContaContext>()
				.UseInMemoryDatabase(databaseName: "WebAPI")
				.Options;

			using (var context = new ContaContext(options))
			{
				ContaPagarController contaPagarController = new ContaPagarController(context);

				var conta = new Conta
				{
					Nome = "Conta 01",
					ValorOriginal = 100,
					DataVencimento = Convert.ToDateTime("2021-01-01"),
					DataPagamento = Convert.ToDateTime("2021-01-01")
				};

				var result = contaPagarController.Post(conta) as ObjectResult;

				Assert.Equal("Conta adicionada com sucesso.", result.Value);
			}
		}

		[Fact]
		public void PostContaPagarInvalido()
		{
			var options = new DbContextOptionsBuilder<ContaContext>()
				.UseInMemoryDatabase(databaseName: "WebAPI")
				.Options;

			using (var context = new ContaContext(options))
			{
				ContaPagarController contaPagarController = new ContaPagarController(context);

				var conta = new Conta
				{
					Nome = "",
					ValorOriginal = 100,
					DataVencimento = Convert.ToDateTime("2021-01-01"),
					DataPagamento = Convert.ToDateTime("2021-01-01")
				};
				
				var result = contaPagarController.Post(conta) as ObjectResult;

				Assert.Equal("Nome da conta é obrigatório", result.Value);
			}
		}
	}
}
