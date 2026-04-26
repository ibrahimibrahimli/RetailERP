using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Command.CreateBrand
{
    public class CreateBrandCommandHandler
     : IRequestHandler<CreateBrandCommand, Result<Guid>>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IBrandReadRepository _brandReadRepository;

        public CreateBrandCommandHandler(
            IBrandWriteRepository brandWriteRepository, IBrandReadRepository brandReadRepository)
        {
            _brandWriteRepository = brandWriteRepository;
            _brandReadRepository = brandReadRepository;
        }

        public async Task<Result<Guid>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            bool brandExists = await _brandReadRepository.ExistsByNameAsync(request.Name);

            if (brandExists)
                return Result<Guid>.Failure("Brand already exists");

            Brand brand = new(
                request.Name,
                request.SubCompanyId);

            await _brandWriteRepository.AddAsync(brand);

            await _brandWriteRepository.SaveChangesAsync();

            return Result<Guid>.Success(brand.Id);
        }
    }
}
