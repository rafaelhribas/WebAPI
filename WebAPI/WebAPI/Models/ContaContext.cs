using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
	public class ContaContext : DbContext
	{
		public ContaContext(DbContextOptions options)
			: base(options)
		{

		}

		public DbSet<Conta> Contas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Conta>(
				c =>
				{
					c.Property(c => c.ValorOriginal).IsRequired();
					c.Property(c => c.DataVencimento).IsRequired();
					c.Property(c => c.DataPagamento).IsRequired();
				});
		}
	}
}
