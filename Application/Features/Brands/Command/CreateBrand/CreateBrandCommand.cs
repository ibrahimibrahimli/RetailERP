using Application.Common.Results;
using MediatR;

namespace Application.Features.Brands.Command.CreateBrand
{
    public sealed record CreateBrandCommand(string Name, Guid SubCompanyId)
      : IRequest<Result<Guid>>;
}
