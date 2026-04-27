using Application.Common.Results;
using MediatR;

namespace Application.Features.SubCompanies.Command
{
    public sealed record CreateSubCompanyCommand(string Name) : IRequest<Result<Guid>>;
}
