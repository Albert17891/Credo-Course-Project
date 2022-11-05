namespace BankSystem.Domain.Models;

using BankSystem.Domain.Models.Enum;

public class Transactions
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public AppUser User { get; set; }

    public string? ReceiverUserId { get; set; }

    public decimal TransferFee { get; set; }

    public decimal TransferAmount { get; set; }

    public DateTime TransactionDate { get; set; }

    public Currency Currency { get; set; }

    public TransactionType TransactionType { get; set; }
}