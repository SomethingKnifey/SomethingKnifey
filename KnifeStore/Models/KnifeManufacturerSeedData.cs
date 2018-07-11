using KnifeStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnifeStore.Models
{
    public class KnifeManufacturerSeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new KnifeDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<KnifeDbContext>>()))
            {
                if (context.Manufacturers.Any())
                {
                    return;
                }

                await context.Manufacturers.AddRangeAsync(
                    new KnifeManufacturer
                    {
                        Name = "Victorinox"
                    },

                    new KnifeManufacturer
                    {
                        Name = "Spyderco"
                    },

                    new KnifeManufacturer
                    {
                        Name = "Zwilling J.A. Henckels"
                    }
                  );

                await context.SaveChangesAsync();
            }
        }
    }
}
