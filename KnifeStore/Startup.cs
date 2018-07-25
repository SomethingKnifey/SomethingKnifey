﻿using KnifeStore.Data;
using KnifeStore.Models;
using KnifeStore.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KnifeStore
{
	public class Startup
    {

		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			var builder = new ConfigurationBuilder().AddEnvironmentVariables();
			builder.AddUserSecrets<Startup>();
			Configuration = builder.Build();
		}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			services.AddDbContext<KnifeDbContext>(options => 
			options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:DefaultIdentityConnection"]));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
					.AddEntityFrameworkStores<ApplicationDbContext>()
					.AddDefaultTokenProviders();

			services.AddAuthorization(options =>
			{
				options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationUserRoles.Admin));
			});

            services.AddAuthentication()
                .AddMicrosoftAccount(microsoftOptions =>{
                microsoftOptions.ClientId = Configuration["OAUTH:Authentication:Microsoft:ClientId"];
                microsoftOptions.ClientSecret = Configuration["OAUTH:Authentication:Microsoft:ClientSecret"];
                 })
                .AddGoogle(googleOptions =>{
                googleOptions.ClientId = Configuration["OAUTH:Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["OAUTH:Authentication:Google:ClientSecret"];
                 });

            services.AddScoped<IInventory, InventoryActionModel>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Something went wrong.");
            });
        }
    }
}
 