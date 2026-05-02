using Application.Common.Results;
using MediatR;

namespace Application.Features.Brands.Command.DeleteBrand
{
    public sealed record DeleteBrandCommand(Guid Id) :IRequest<Result>;
}
