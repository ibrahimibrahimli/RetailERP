using Application.Common.Results;
using MediatR;
using System.Globalization;

namespace Application.Features.Branches.Commands.CreateBranch
{
    public sealed record CreateBranchCommand(
        string Name,
        string Address,
        string PhoneNumber,
        Guid BrandId) : IRequest<Result<Guid>>;
}
