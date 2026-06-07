using Application.Common.Results;
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
                .Where(x => !x.IsDeleted)
                .GroupBy(x => x.EmployeeId)
                .Select(g => new
                {
                    EmployeeId = g.Key,
                    SalesCount = g.Count(),
                    Revenue = g.Sum(x => x.TotalAmount)
                })
                .Join(
                    Context.Employees,
                    s => s.EmployeeId,
                    e => e.Id,
                    (s, e) => new
                    {
                        e.Id,
                        e.EmployeeCode,
                        e.FirstName,
                        e.LastName,
                        s.SalesCount,
                        s.Revenue
                    })
                .OrderByDescending(x => x.Revenue) 
                .Take(count)
                .Select(x => new TopEmployeeDto(
                    x.Id,
                    x.EmployeeCode,
                    x.FirstName + " " + x.LastName,
                    x.SalesCount,
                    x.Revenue))
                .ToListAsync();
        }
    }
}
