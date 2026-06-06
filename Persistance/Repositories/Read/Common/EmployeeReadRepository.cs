using Application.Features.Employees.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public sealed class EmployeeReadRepository : ReadRepository<Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<List<Employee>> GetAllByBranchAsync()
        {
            return await Context.Employees
                .AsNoTracking()
                .Include(x => x.Branch)
                .ToListAsync();
        }

        public async Task<List<TopEmployeeDto>> GetTopEmployeesAsync(int count)
        {
            return await Context.Sales
                .AsNoTracking()
                .Include(x => x.Employee)
                .Where(x => !x.IsDeleted)
                .GroupBy(x => new
                {
                    x.EmployeeId,
                    x.Employee.EmployeeCode,
                    x.Employee.FirstName,
                    x.Employee.LastName,
                })
                .Select(x => new TopEmployeeDto(
                    x.Key.EmployeeId,
                    x.Key.EmployeeCode,
                    $"{x.Key.FirstName} {x.Key.LastName}",
                    x.Count(),
                    x.Sum(s => s.TotalAmount)))
                .OrderByDescending(x => x.Revenue)
                .Take(count)
                .ToListAsync();
        }
    }
}
