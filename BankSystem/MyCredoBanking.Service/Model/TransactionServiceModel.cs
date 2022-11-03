using BankSystem.Domain.Models.Enum;

namespace MyCredoBanking.Service.Model;

public class TransactionServiceModel
{
    public int SenderAccountId { get; set; }

    public int RecieverAccountId { get; set; }

    public decimal Amount { get; set; }
}