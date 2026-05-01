using Application.Common.Results;
using MediatR;

namespace Application.Features.Brands.Command.UpdateBrandName
{
    public sealed record UpdateBrandNameCommand(Guid Id, string Name) : IRequest<Result>;
}
