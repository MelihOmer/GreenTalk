﻿// <auto-generated />
using System;
using GreenTalk.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GreenTalk.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241208022053_seedData")]
    partial class seedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GreenTalk.Core.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("GreenTalk.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e56f6d4c-b396-42d3-bdd5-109e1d519aa4"),
                            Email = "melih@mail.com",
                            PasswordHash = "123456",
                            Username = "melih.kamar"
                        },
                        new
                        {
                            Id = new Guid("c792249f-db81-4cf6-99a8-614720e9250d"),
                            Email = "tugba@mail.com",
                            PasswordHash = "654321",
                            Username = "tugba.kamar"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
