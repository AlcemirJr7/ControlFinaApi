using ControlFinaApi.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ControlFinaApi.Features.Transactions.Contracts.Requests
{
    public class UpdateTransactionRequest
    {
        public Guid Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string TransactionDate { get; set; } = DateTime.Now.ToDateOnlyIso();
        public Guid HistoryId { get; set; }
        public decimal Value { get; set; } = 0;
    }
}
