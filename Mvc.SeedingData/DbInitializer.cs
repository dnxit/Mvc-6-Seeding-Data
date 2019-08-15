using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Mvc.SeedingData.Data;
using System;
using System.Linq;

namespace Mvc.SeedingData
{
	public static class DbInitializer
	{
		public static void Initialize(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
				context.Database.EnsureCreated();

				var _userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
				var _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

				if (!context.Users.Any(usr => usr.UserName == "demo@test.com"))
				{
					var user = new IdentityUser()
					{
						UserName = "demo@test.com",
						Email = "demo@test.com",
						EmailConfirmed = true,
					};

					var userResult = _userManager.CreateAsync(user, "P@ssw0rd").Result;
				}

				if (!_roleManager.RoleExistsAsync("Admin").Result)
				{
					var role = _roleManager.CreateAsync
							   (new IdentityRole { Name = "Admin" }).Result;
				}

				var adminUser = _userManager.FindByNameAsync("demo@test.com").Result;
				var userRole = _userManager.AddToRolesAsync
							   (adminUser, new string[] { "Admin" }).Result;


				var terminal = context.Terminal
								  .Where(x => x.Name == "Test").FirstOrDefault();

				if (terminal == null)
				{
					terminal = new Terminal()
					{
						Name = "Test",
						CreatedDate = DateTime.Now,
					};


					context.Terminal.Add(terminal);

				}

				context.SaveChanges();
			}
		}
	}
}