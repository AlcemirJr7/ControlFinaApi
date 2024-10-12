using ControlFinaApi.Entities;
using ControlFinaApi.Extensions;
using ControlFinaApi.Features.Transactions.Contracts.Responses;

namespace ControlFinaApi.Features.Transactions.Mappings
{
    public class TransactionMapping
    {
        public static TransactionResponse ToResponse(Transaction transaction)
        {
            return new TransactionResponse
            {
                Id = transaction.Id,
                TransactionDate = transaction.TransactionDate.ToDateOnlyIso(),
                HistoryId = transaction.HistoryId,
                Value = transaction.Value,
                CreatedAt = transaction.CreatedAt,
            };
        }

        public static IEnumerable<TransactionResponse> ToResponse(IEnumerable<Transaction> transactions)
        {

            foreach (var transaction in transactions)
            {
                yield return new TransactionResponse
                {
                    Id = transaction.Id,
                    TransactionDate = transaction.TransactionDate.ToDateOnlyIso(),
                    HistoryId = transaction.HistoryId,
                    Value = transaction.Value,
                    CreatedAt = transaction.CreatedAt,
                };
            }
        }
    }
}
