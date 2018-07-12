using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace KnifeStore.Data
{
	public class KnifeDbContext : DbContext
	{
		public KnifeDbContext(DbContextOptions<KnifeDbContext> options) : base(options)
		{
		}

		public DbSet<KnifeManufacturer> Manufacturers { get; set; }
		public DbSet<Knife> Knives { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Knife>().HasData(
				new Knife
				{
					ID = 1,
					SKU = "Vic-Tin-01",
					//ManufacturerID = 1,
					Model = "Tinker",
					Description = "",
					Price = 19.99m,
					Image = "",
					Style = (Style)1
				},

					new Knife
					{
						ID = 2,
						SKU = "Vic-Cyb-Lit-01",
						//ManufacturerID = 1,
						Model = "CyberTool Lite",
						Description = "",
						Price = 109.95m,
						Image = "",
						Style = (Style)1
					},

					new Knife
					{
						ID = 3,
						SKU = "Vic-Cad-Alo-01",
						//ManufacturerID = 1,
						Model = "Cadet Alox",
						Description = "",
						Price = 24.95m,
						Image = "",
						Style = (Style)1
					},

					new Knife
					{
						ID = 4,
						SKU = "Spy-Bra-Bow-01",
						//ManufacturerID = 1,
						Model = "Bradly Bowie",
						Description = "",
						Price = 399.99m,
						Image = "",
						Style = (Style)2
					},

					new Knife
					{
						ID = 5,
						SKU = "Spy-Spr-01",
						//ManufacturerID = 1,
						Model = "Sprig",
						Description = "",
						Price = 209.99m,
						Image = "",
						Style = (Style)2
					},

					new Knife
					{
						ID = 6,
						SKU = "Spy-Sus-01",
						//ManufacturerID = 1,
						Model = "Sustain",
						Description = "",
						Price = 249.99m,
						Image = "",
						Style = (Style)2
					},

					new Knife
					{
						ID = 7,
						SKU = "Pro-5in-Z15-Ser-01",
						//ManufacturerID = 2,
						Model = "Pro 5in. Z15 Serrated",
						Description = "",
						Price = 59.99m,
						Image = "",
						Style = (Style)0
					},

					new Knife
					{
						ID = 8,
						SKU = "Twi-Sig-6in-01",
						//ManufacturerID = 2,
						Model = "TWIN Signature 6in.",
						Description = "",
						Price = 19.99m,
						Image = "",
						Style = (Style)0
					},

					new Knife
					{
						ID = 9,
						SKU = "Fou-Sta-6in-01",
						//ManufacturerID = 2,
						Model = "Four Star 6in.",
						Description = "",
						Price = 59.99m,
						Image = "",
						Style = (Style)0
					},

					new Knife
					{
						ID = 10,
						SKU = "Int-Sil-6in-01",
						//ManufacturerID = 2,
						Model = "International Silvercap 6in.",
						Description = "",
						Price = 9.95m,
						Image = "",
						Style = (Style)0
					}
				);

			modelBuilder.Entity<KnifeManufacturer>().HasData(

				 new KnifeManufacturer
				 {
					 ID = 1,
					 Name = "Victorinox"
				 },

					new KnifeManufacturer
					{
						ID = 2,
						Name = "Spyderco"
					},

					new KnifeManufacturer
					{
						ID = 3,
						Name = "Zwilling J.A. Henckels"
					}
				);



		}
	}
}
