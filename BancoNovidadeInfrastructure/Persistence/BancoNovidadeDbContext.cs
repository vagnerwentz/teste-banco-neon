using System;
using System.Reflection;
using BancoNovidadeCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BancoNovidadeInfrastructure.Persistence
{
    public class BancoNovidadeDbContext : DbContext
    {
        public BancoNovidadeDbContext(DbContextOptions<BancoNovidadeDbContext> options) : base(options)
        {
        }

        public DbSet<Deposit> Deposits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

