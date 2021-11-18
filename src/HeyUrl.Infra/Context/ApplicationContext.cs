using HeyUrl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HeyUrl.Infra.Context
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Url> Url { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<Browser> Browser { get; set; }
        public DbSet<Click> Click { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                        => optionsBuilder.LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.Entity<Click>()
                        .HasOne(u => u.Url)
                        .WithMany(c => c.Click)
                        .HasForeignKey(k => k.UrlId);

            modelbuilder.Entity<Platform>()
                        .HasOne(c => c.Click)
                        .WithOne(p => p.Platform)
                        .HasForeignKey<Platform>(k => k.ClickId);

            modelbuilder.Entity<Browser>()
                        .HasOne(c => c.Platform)
                        .WithOne (b => b.Browser)
                        .HasForeignKey<Browser>(k => k.PlatformId);

            modelbuilder.HasSequence($"sequence-{nameof(Url)}");            

        }

    }
}