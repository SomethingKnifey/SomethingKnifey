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
					Description = "One knife to rule them all.",
					Price = 19.99m,
					Image = "https://assets.victorinox.com/mam/celum/celum_assets/0dc/26c/8868161683486_celum_129756_2000Wx1750H.jpg",
					Style = (Style)1
				},

					new Knife
					{
						ID = 2,
						SKU = "Vic-Cyb-Lit-01",
						//ManufacturerID = 1,
						Model = "CyberTool Lite",
						Description = "The best knife you can ever have.",
						Price = 109.95m,
						Image = "https://assets.victorinox.com/mam/celum/celum_assets/bcc/3cc/8870039420958_celum_131868_2000Wx1750H.jpg",
						Style = (Style)1
					},

					new Knife
					{
						ID = 3,
						SKU = "Vic-Cad-Alo-01",
						//ManufacturerID = 1,
						Model = "Cadet Alox",
						Description = "The second best knife you can ever have.",
						Price = 24.95m,
						Image = "https://assets.victorinox.com/mam/celum/celum_assets/17c/6fc/8921382780958_celum_139682_2000Wx1750H.jpg",
						Style = (Style)1
					},

					new Knife
					{
						ID = 4,
						SKU = "Spy-Bra-Bow-01",
						//ManufacturerID = 1,
						Model = "Bradly Bowie",
						Description = "Like David Bowie, except pointer.",
						Price = 399.99m,
						Image = "https://assets.brandfolder.com/rxlnjq51/element@2x.png",
						Style = (Style)2
					},

					new Knife
					{
						ID = 5,
						SKU = "Spy-Spr-01",
						//ManufacturerID = 1,
						Model = "Sprig",
						Description = "This will butter your bread.",
						Price = 209.99m,
						Image = "https://assets.brandfolder.com/ogsobg-3cul54-5t2tsa/element@2x.png",
						Style = (Style)2
					},

					new Knife
					{
						ID = 6,
						SKU = "Spy-Sus-01",
						//ManufacturerID = 1,
						Model = "Sustain",
						Description = "You can buy this one if you are a spy.",
						Price = 249.99m,
						Image = "https://assets.brandfolder.com/o83xtl-8lo96w-fuvlw8/element@2x.png",
						Style = (Style)2
					},

					new Knife
					{
						ID = 7,
						SKU = "Pro-5in-Z15-Ser-01",
						//ManufacturerID = 2,
						Model = "Pro 5in. Z15 Serrated",
						Description = "Butter knife with serrated edges.",
						Price = 59.99m,
						Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg",
						Style = (Style)0
					},

					new Knife
					{
						ID = 8,
						SKU = "Twi-Sig-6in-01",
						//ManufacturerID = 2,
						Model = "TWIN Signature 6in.",
						Description = "Another knife.",
						Price = 19.99m,
						Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg",
						Style = (Style)0
					},

					new Knife
					{
						ID = 9,
						SKU = "Fou-Sta-6in-01",
						//ManufacturerID = 2,
						Model = "Four Star 6in.",
						Description = "Four stars.",
						Price = 59.99m,
						Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg",
						Style = (Style)0
					},

					new Knife
					{
						ID = 10,
						SKU = "Int-Sil-6in-01",
						//ManufacturerID = 2,
						Model = "International Silvercap 6in.",
						Description = "International travel knife.",
						Price = 9.95m,
						Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg",
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
