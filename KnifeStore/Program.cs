using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Data;
using KnifeStore.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KnifeStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

			var host = CreateWebHostBuilder(args).Build();

			//using(var scope = host.Services.CreateScope())
			//{
			//  var services = scope.ServiceProvider;

			//	try
			//	{
			//		var context = services.GetRequiredService<KnifeDbContext>();
			//		context.Database.Migrate();
			//	KnifeSeedData.Initialize(services);
			//		KnifeManufacturerSeedData.Initialize(services);


			//	} catch(Exception x)
			//	{
			//		var logger = services.GetRequiredService<ILogger<Program>>();
			//		logger.LogError(x, "An error occurred seeding the Database.");
			//	}
			//}
			//host.Run();
        }



        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
