using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Branches.Commands.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Result<Guid>>
    {
        private readonly IBranchWriteRepository _writeRepository;
        private readonly IBranchReadRepository _readRepository;

        public CreateBranchCommandHandler(IBranchWriteRepository writeRepository, IBranchReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Result<Guid>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            bool isExists = await _readRepository.ExistsByNameAsync(request.BrandId, request.Name);
            if (isExists)
                return Result<Guid>.Failure($"{request.Name} already exists in this brand");

            Branch branch = Branch.Create(
                request.Name,
                request.Address,
                request.PhoneNumber,
                request.BrandId);

            await _writeRepository.AddAsync(branch);
            await _writeRepository.SaveChangesAsync();

            return Result<Guid>.Success(branch.Id);
        }
    }
}
