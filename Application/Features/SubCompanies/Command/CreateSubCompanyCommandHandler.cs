using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.SubCompanies.Command
{
    public class CreateSubCompanyCommandHandler : IRequestHandler<CreateSubCompanyCommand, Result<Guid>>
    {
        private readonly ISubCompanyWriteRepository _writeRepository;
        private readonly ISubCompanyReadRepository _readRepository;
        public CreateSubCompanyCommandHandler(ISubCompanyWriteRepository writeRepository, ISubCompanyReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Result<Guid>> Handle(CreateSubCompanyCommand request, CancellationToken cancellationToken)
        {
            bool subCompanyExists = await _readRepository.ExistsByNameAsync(request.Name);
            if (subCompanyExists) return Result<Guid>.Failure("SubComoany already exists");

            SubCompany subCompany = SubCompany.Create(request.Name);

            await _writeRepository.AddAsync(subCompany);

            await _writeRepository.SaveChangesAsync();

            return Result<Guid>.Success(subCompany.Id);
        }
    }
}
