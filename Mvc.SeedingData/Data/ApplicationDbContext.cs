using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Mvc.SeedingData.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		public DbSet<Terminal> Terminal { get; set; }
	}

	public class Terminal
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime CreatedDate { get; set; }
	}
}