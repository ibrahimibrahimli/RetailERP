using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.Brands.Command.UpdateBrandName
{
    public class UpdateBrandNameCommandHandler : IRequestHandler<UpdateBrandNameCommand, Result>
    { 
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IBrandWriteRepository _brandWriteRepository;

        public UpdateBrandNameCommandHandler(IBrandReadRepository brandReadRepository, IBrandWriteRepository brandWriteRepository)
        {
            _brandReadRepository = brandReadRepository;
            _brandWriteRepository = brandWriteRepository;
        }

        public async Task<Result> Handle(UpdateBrandNameCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandReadRepository.GetTrackedByIdAsync(request.Id);
            if (brand == null)
                return Result.Failure("Brand not found");
            
            bool brandExists = await _brandReadRepository.ExistsByNameAsync(request.Name);
            if (brandExists)
                return Result.Failure($"{brand.Name} already exists");

            brand.UpdateName(request.Name);

            await _brandWriteRepository.SaveChangesAsync();

            return Result.Success();
        }
    }
}
