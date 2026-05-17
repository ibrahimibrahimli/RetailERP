using Domain.Enums;

namespace Application.Features.InventoryTransactions.DTOs
{
    public sealed record InventoryTransactionDto(
        Guid Id,
        InventoryTransactionType Type,
        int Quantity,
        string Description,
        DateTime CreatedAt);
}
