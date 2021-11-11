using HeyUrl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeyUrl.Infra.Context
{
    public class ApplicationContext : DbContext
    {

        public DbSet<UrlEntity> Url { get; set; }
        public DbSet<PlatformEntity> Platform { get; set; }
        public DbSet<ClickEntity> Click { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            
            modelbuilder.Entity<UrlEntity>()
                        .Property(u => u.ShortUrlId)
                        .UseHiLo("urlHilo");

            modelbuilder.Entity<UrlEntity>()
                        .HasOne(c => c.Click)
                        .WithOne()
                        .HasForeignKey()
            
                        
        }

    }
}