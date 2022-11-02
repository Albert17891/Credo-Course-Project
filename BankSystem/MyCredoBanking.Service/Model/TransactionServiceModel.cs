using BankSystem.Domain.Models.Enum;

namespace MyCredoBanking.Service.Model;

public class TransactionServiceModel
{
    public string UserId { get; set; }

    public string ReceiverUserId { get; set; }

    public decimal TransferFee { get; set; }

    public decimal TransferAmount { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal TransactionIncome { get; set; }

    public TransactionType TransactionType { get; set; }
}
