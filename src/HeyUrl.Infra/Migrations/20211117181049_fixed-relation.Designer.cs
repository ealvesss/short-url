﻿// <auto-generated />
using System;
using HeyUrl.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HeyUrl.Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211117181049_fixed-relation")]
    partial class fixedrelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.HasSequence("sequence-Click");

            modelBuilder.HasSequence("sequence-Url");

            modelBuilder.Entity("HeyUrl.Domain.Entities.Browser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("PlatformId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId")
                        .IsUnique();

                    b.ToTable("Browser");
                });

            modelBuilder.Entity("HeyUrl.Domain.Entities.Click", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ClickedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UrlId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UrlId");

                    b.ToTable("Click");
                });

            modelBuilder.Entity("HeyUrl.Domain.Entities.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClickId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClickId")
                        .IsUnique();

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("HeyUrl.Domain.Entities.Url", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("OriginalUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Url");
                });

            modelBuilder.Entity("HeyUrl.Domain.Entities.Browser", b =>
                {
                    b.HasOne("HeyUrl.Domain.Entities.Platform", "Platform")
                        .WithOne("Browser")
                        .HasForeignKey("HeyUrl.Domain.Entities.Browser", "PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("HeyUrl.Domain.Entities.Click", b =>
                {
                    b.HasOne("HeyUrl.Domain.Entities.Url", "Url")
                        .WithMany("Click")
                        .HasForeignKey("UrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Url");
                });

            modelBuilder.Entity("HeyUrl.Domain.Entities.Platform", b =>
                {
                    b.HasOne("HeyUrl.Domain.Entities.Click", "Click")
                        .WithOne("Platform")
                        .HasForeignKey("HeyUrl.Domain.Entities.Platform", "ClickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Click");
                });

            modelBuilder.Entity("HeyUrl.Domain.Entities.Click", b =>
                {
                    b.Navigation("Platform");
                });

            modelBuilder.Entity("HeyUrl.Domain.Entities.Platform", b =>
                {
                    b.Navigation("Browser");
                });

            modelBuilder.Entity("HeyUrl.Domain.Entities.Url", b =>
                {
                    b.Navigation("Click");
                });
#pragma warning restore 612, 618
        }
    }
}