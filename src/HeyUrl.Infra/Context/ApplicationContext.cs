using HeyUrl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HeyUrl.Infra.Context
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Url> Url { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<Click> Click { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                        => optionsBuilder.LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Click>()
                        .HasOne(b => b.Url)
                        .WithOne(i => i.Click)
                        .HasForeignKey<Click>(k => k.UrlId);

            modelbuilder.HasSequence($"sequence-{nameof(Url)}");
            modelbuilder.HasSequence($"sequence-{nameof(Click)}");
            

        }

    }
}