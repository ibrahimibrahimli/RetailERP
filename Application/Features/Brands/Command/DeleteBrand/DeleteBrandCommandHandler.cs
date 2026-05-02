using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.Brands.Command.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Result>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IBrandReadRepository _brandReadRepository;

        public DeleteBrandCommandHandler(IBrandWriteRepository brandWriteRepository, IBrandReadRepository brandReadRepository)
        {
            _brandWriteRepository = brandWriteRepository;
            _brandReadRepository = brandReadRepository;
        }

        public async Task<Result> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandReadRepository.GetTrackedByIdAsync(request.Id);
            if (brand == null)
                return Result.Failure("Brand not found");

            brand.Delete();

            await _brandWriteRepository.SaveChangesAsync();

            return Result.Success();
        }
    }
}
