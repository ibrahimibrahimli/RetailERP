using Application.Common.Results;
using Application.Features.Sales.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;
using System.Formats.Tar;

namespace Application.Features.Sales.Queries.GetSalesByBranch
{
    public sealed class GetSalesByBranchQueryHandler : IRequestHandler<GetSalesByBranchQuery, Result<List<SaleListDto>>>
    {
        private readonly ISaleReadRepository _saleReadRepository;

        public GetSalesByBranchQueryHandler(ISaleReadRepository saleReadRepository)
        {
            _saleReadRepository = saleReadRepository;
        }

        public async Task<Result<List<SaleListDto>>> Handle(GetSalesByBranchQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleReadRepository.GetSalesByBranchAsync(request.BranchId);
            if (sales is null)
                return Result<List<SaleListDto>>.Failure("Sales Not found");

            var response = sales.Select(x => new SaleListDto(
                x.Id,
                x.InvoiceNumber,
                x.TotalAmount,
                x.PaymentMethod,
                x.SaleDate)).ToList();

            return Result<List<SaleListDto>>.Success(response);
        }
    }
}
