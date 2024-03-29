﻿// <auto-generated />
using ArtworkStore.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArtworkStore.Domain.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20220903082020_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ArtworkStore.Domain.Entities.Artwork", b =>
                {
                    b.Property<int>("ArtworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("artwork_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Author")
                        .HasColumnName("author")
                        .HasColumnType("text");

                    b.Property<long>("CreationDate")
                        .HasColumnName("creation_date")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnName("descriprion")
                        .HasColumnType("text");

                    b.Property<string>("Format")
                        .HasColumnName("format")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("numeric");

                    b.Property<string>("Technic")
                        .HasColumnName("technic")
                        .HasColumnType("text");

                    b.HasKey("ArtworkId");

                    b.ToTable("artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
