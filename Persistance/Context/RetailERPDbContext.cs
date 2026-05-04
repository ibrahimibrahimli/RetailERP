using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class RetailERPDbContext : DbContext
    {
        public RetailERPDbContext(DbContextOptions<RetailERPDbContext> options) : base(options)
        {}

        public DbSet<SubCompany> SubCompanies => Set<SubCompany>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Branch> Branches => Set<Branch>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RetailERPDbContext).Assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }
}
