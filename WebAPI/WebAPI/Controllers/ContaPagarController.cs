using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;


namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContaPagarController : ControllerBase
	{
		private readonly ContaContext _contaContext;

		public ContaPagarController(ContaContext context)
		{
			_contaContext = context;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var result = _contaContext.Contas.ToList();
			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Post([FromBody] Conta conta)
		{
			if (conta == null)
			{
				return BadRequest("Conta é null.");
			}

			if (conta.IsValid())
			{
				conta.Calcular();
				_contaContext.Add(conta);
				_contaContext.SaveChanges();
				return Ok("Conta adicionada com sucesso.");
			}
			else
			{
				return BadRequest(conta.Errors());
			}

		}
	}
}
