using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RetailERP.Domain.Entities;

namespace Persistance.Context
{
    public class RetailERPDbContext : DbContext
    {
        public RetailERPDbContext(DbContextOptions<RetailERPDbContext> options) : base(options)
        {}

        public DbSet<SubCompany> SubCompanies => Set<SubCompany>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<BranchInventory> BranchInventories => Set<BranchInventory>();
        public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();
        public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<EmployeeTransfer> EmployeeTransfers => Set<EmployeeTransfer>();
        public DbSet<BonusRule> BonusRules => Set<BonusRule>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RetailERPDbContext).Assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }
}
