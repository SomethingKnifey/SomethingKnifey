﻿// <auto-generated />
using System;
using KnifeStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KnifeStore.Migrations
{
    [DbContext(typeof(KnifeDbContext))]
    [Migration("20180718202008_seedData2")]
    partial class seedData2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KnifeStore.Models.Knife", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<int?>("ManufacturerID");

                    b.Property<string>("Model");

                    b.Property<decimal>("Price");

                    b.Property<string>("SKU");

                    b.Property<int>("Style");

                    b.HasKey("ID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("Knives");

                    b.HasData(
                        new { ID = 1, Description = "One knife to rule them all.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "Tinker", Price = 19.99m, SKU = "Vic-Tin-01", Style = 1 },
                        new { ID = 2, Description = "The best knife you can ever have.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "CyberTool Lite", Price = 109.95m, SKU = "Vic-Cyb-Lit-01", Style = 1 },
                        new { ID = 3, Description = "The second best knife you can ever have.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "Cadet Alox", Price = 24.95m, SKU = "Vic-Cad-Alo-01", Style = 1 },
                        new { ID = 4, Description = "Like David Bowie, except pointer.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "Bradly Bowie", Price = 399.99m, SKU = "Spy-Bra-Bow-01", Style = 2 },
                        new { ID = 5, Description = "This will butter your bread.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "Sprig", Price = 209.99m, SKU = "Spy-Spr-01", Style = 2 },
                        new { ID = 6, Description = "You can buy this one if you are a spy.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "Sustain", Price = 249.99m, SKU = "Spy-Sus-01", Style = 2 },
                        new { ID = 7, Description = "Butter knife with serrated edges.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "Pro 5in. Z15 Serrated", Price = 59.99m, SKU = "Pro-5in-Z15-Ser-01", Style = 0 },
                        new { ID = 8, Description = "Another knife.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "TWIN Signature 6in.", Price = 19.99m, SKU = "Twi-Sig-6in-01", Style = 0 },
                        new { ID = 9, Description = "Four stars.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "Four Star 6in.", Price = 59.99m, SKU = "Fou-Sta-6in-01", Style = 0 },
                        new { ID = 10, Description = "International travel knife.", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", Model = "International Silvercap 6in.", Price = 9.95m, SKU = "Int-Sil-6in-01", Style = 0 }
                    );
                });

            modelBuilder.Entity("KnifeStore.Models.KnifeManufacturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new { ID = 1, Name = "Victorinox" },
                        new { ID = 2, Name = "Spyderco" },
                        new { ID = 3, Name = "Zwilling J.A. Henckels" }
                    );
                });

            modelBuilder.Entity("KnifeStore.Models.Knife", b =>
                {
                    b.HasOne("KnifeStore.Models.KnifeManufacturer", "Manufacturer")
                        .WithMany("Knives")
                        .HasForeignKey("ManufacturerID");
                });
#pragma warning restore 612, 618
        }
    }
}
