using Application.Common.Results;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Command.CreateBrand
{
    public class CreateBrandCommandHandler
     : IRequestHandler<CreateBrandCommand, Result<Guid>>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;

        public CreateBrandCommandHandler(
            IBrandWriteRepository brandWriteRepository)
        {
            _brandWriteRepository = brandWriteRepository;
        }

        public async Task<Result<Guid>> Handle(
            CreateBrandCommand request,
            CancellationToken cancellationToken)
        {
            Brand brand = new(
                request.Name,
                request.SubCompanyId);

            await _brandWriteRepository.AddAsync(brand);

            await _brandWriteRepository.SaveChangesAsync();

            return Result<Guid>.Success(brand.Id);
        }
    }
}
