using AutoRep1.Data.Models;
using Microsoft.EntityFrameworkCore;

    public class EducationContext : DbContext
    {
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Service> Services { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        optionsBuilder.UseNpgsql(@"Host=localhost;Database=education1;Username=postgres;Password=dmitry1")
                .UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Service>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>().Property(p => p.Id).ValueGeneratedOnAdd();

        }
    }