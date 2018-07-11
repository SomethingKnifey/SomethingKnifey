using KnifeStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnifeStore.Models
{
    public class KnifeSeedData
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
                        Model = "Tinker",
                        Description = "",
                        Price = 19.99m,
                        Image = "",
                        Style = (Style)1
                    },

                    new Knife
                    {
                        SKU = "Vic-Cyb-Lit-01",
                        ManufacturerID = 0,
                        Model = "CyberTool Lite",
                        Description = "",
                        Price = 109.95m,
                        Image = "",
                        Style = (Style)1
                    },

                    new Knife
                    {
                        SKU = "Vic-Cad-Alo-01",
                        ManufacturerID = 0,
                        Model = "Cadet Alox",
                        Description = "",
                        Price = 24.95m,
                        Image = "",
                        Style = (Style)1
                    },

                    new Knife
                    {
                        SKU = "Spy-Bra-Bow-01",
                        ManufacturerID = 1,
                        Model = "Bradly Bowie",
                        Description = "",
                        Price = 399.99m,
                        Image = "",
                        Style = (Style)2
                    },

                    new Knife
                    {
                        SKU = "Spy-Spr-01",
                        ManufacturerID = 1,
                        Model = "Sprig",
                        Description = "",
                        Price = 209.99m,
                        Image = "",
                        Style = (Style)2
                    },

                    new Knife
                    {
                        SKU = "Spy-Sus-01",
                        ManufacturerID = 1,
                        Model = "Sustain",
                        Description = "",
                        Price = 249.99m,
                        Image = "",
                        Style = (Style)2
                    },

                    new Knife
                    {
                        SKU = "Pro-5in-Z15-Ser-01",
                        ManufacturerID = 2,
                        Model = "Pro 5in. Z15 Serrated",
                        Description = "",
                        Price = 59.99m,
                        Image = "",
                        Style = (Style)0
                    },

                    new Knife
                    {
                        SKU = "Twi-Sig-6in-01",
                        ManufacturerID = 2,
                        Model = "TWIN Signature 6in.",
                        Description = "",
                        Price = 19.99m,
                        Image = "",
                        Style = (Style)0
                    },

                    new Knife
                    {
                        SKU = "Fou-Sta-6in-01",
                        ManufacturerID = 2,
                        Model = "Four Star 6in.",
                        Description = "",
                        Price = 59.99m,
                        Image = "",
                        Style = (Style)0
                    },

                    new Knife
                    {
                        SKU = "Int-Sil-6in-01",
                        ManufacturerID = 2,
                        Model = "International Silvercap 6in.",
                        Description = "",
                        Price = 9.95m,
                        Image = "",
                        Style = (Style)0
                    }
                  );

                await context.SaveChangesAsync();
            }
        }
    }
}
