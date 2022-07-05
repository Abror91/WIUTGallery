﻿// <auto-generated />
using System;
using DemoWIUTGallery.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoWIUTGallery.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoWIUTGallery.Models.Entities.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(5268),
                            Name = "Books",
                            UpdatedDate = new DateTime(2022, 7, 5, 13, 55, 33, 939, DateTimeKind.Local).AddTicks(8479)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(5996),
                            Name = "Mountains",
                            UpdatedDate = new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(5991)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(6016),
                            Name = "Lakes",
                            UpdatedDate = new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(6015)
                        });
                });

            modelBuilder.Entity("DemoWIUTGallery.Models.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FolderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Photoes");
                });

            modelBuilder.Entity("DemoWIUTGallery.Models.Entities.Photo", b =>
                {
                    b.HasOne("DemoWIUTGallery.Models.Entities.Folder", "Folder")
                        .WithMany("Photoes")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
