using Application.Common.Results;
using Application.Features.SubCompanies.DTOs;
using MediatR;

namespace Application.Features.SubCompanies.Queries
{
    public sealed record GetAllSubCompaniesQuery : IRequest<Result<List<SubCompanyDto>>>;
}
