using ControlFinaApi.Extensions;
using ControlFinaApi.Features.Transactions.Contracts.Requests;

namespace ControlFinaApi.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public Guid HistoryId { get; private set; }
        public History? Historico { get; private set; }
        public decimal Value { get; private set; } = 0;
        public DateTime CreatedAt { get; private set; }

        public Transaction(DateTime transactionDate, Guid historyId, decimal value)
        {
            Id = Guid.NewGuid();
            TransactionDate = transactionDate;
            HistoryId = historyId;
            Value = value;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(DateTime transactionDate, Guid historyId, decimal value)
        {
            TransactionDate = transactionDate;
            HistoryId = historyId;
            Value = value;
        }

        public void Update(UpdateTransactionRequest request)
        {
            TransactionDate = request.TransactionDate.ToDateOnlyIso();
            HistoryId = request.HistoryId;
            Value = request.Value;
        }
    }
}
