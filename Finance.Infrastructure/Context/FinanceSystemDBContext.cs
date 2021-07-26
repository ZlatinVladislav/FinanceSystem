using FinanceSystem.Infrastructure.ConfigTable;
using FinanceSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceSystem.Infrastructure.Context
{
    public class FinanceSystemDBContext : DbContext
    {
        public FinanceSystemDBContext(DbContextOptions<FinanceSystemDBContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TransactionConfig());
            modelBuilder.ApplyConfiguration(new TransactionTypeConfig());
            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) base.OnConfiguring(optionsBuilder);
        }
    }
}
