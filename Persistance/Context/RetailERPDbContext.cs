using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class RetailERPDbContext : DbContext
    {
        public RetailERPDbContext(DbContextOptions<RetailERPDbContext> options) : base(options)
        {}

        public DbSet<SubCompany> SubCompanies => Set<SubCompany>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RetailERPDbContext).Assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }
}
