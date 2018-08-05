using KnifeStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnifeStore.Models
{
    public class StartupDbInitializer
    {
		private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
		{
			new IdentityRole {Name = ApplicationUserRoles.Admin,
								NormalizedName = ApplicationUserRoles.Admin.ToUpper(),
								ConcurrencyStamp = Guid.NewGuid().ToString() },
			new IdentityRole {Name = ApplicationUserRoles.Member,
								NormalizedName = ApplicationUserRoles.Member.ToUpper(),
								ConcurrencyStamp = Guid.NewGuid().ToString()}
		};

		public static void SeedData(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
		{
			using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
			{
				dbContext.Database.EnsureCreated();
				AddRoles(dbContext);
			};
		}

		private static void AddRoles(ApplicationDbContext dbContext)
		{
			if (dbContext.Roles.Any()) return;
			foreach (var role in Roles)
			{
				dbContext.Roles.Add(role);
				dbContext.SaveChanges();
			}
		}
    }
}
