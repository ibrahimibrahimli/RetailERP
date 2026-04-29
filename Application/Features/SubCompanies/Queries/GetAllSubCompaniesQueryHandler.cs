using Application.Common.Results;
using Application.Features.SubCompanies.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.SubCompanies.Queries
{
    public class GetAllSubCompaniesQueryHandler : IRequestHandler<GetAllSubCompaniesQuery, Result<List<SubCompanyDto>>>
    {
        private readonly ISubCompanyReadRepository _readRepository;

        public GetAllSubCompaniesQueryHandler(ISubCompanyReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Result<List<SubCompanyDto>>> Handle(GetAllSubCompaniesQuery request, CancellationToken cancellationToken)
        {
            var subCompanies = await _readRepository.GetAllActiveAsync();

            List<SubCompanyDto> result = [.. subCompanies
            .Select(x => new SubCompanyDto
              (
               x.Id,
               x.Name,
               x.IsActive
              ))];

            return Result<List<SubCompanyDto>>.Success(result);
        }
    }
}
