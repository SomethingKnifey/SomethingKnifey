using KnifeStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnifeStore.Models
{
    public class KnifeDbSeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new KnifeDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<KnifeDbContext>>()))
            {
                if (context.Knives.Any())
                {
                    return;
                }

                await context.Knives.AddRangeAsync(
                    new Knife
                    {
                        SKU = "Vic-Tin-01",
                        ManufacturerID = 0,
                        Manufacturer = "Victorinox",
                        Model = "Tinker",
                        Description = "",
                        Price = 19.99,
                        
                    }


                    );

                await context.SaveChangesAsync();
            }
        }
    }
}
