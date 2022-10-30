namespace BankSystem.Domain.Models.Transactions;
public class ExchangeTransaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal TransferAmount { get; set; }
}
