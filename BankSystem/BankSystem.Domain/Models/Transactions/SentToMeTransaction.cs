namespace BankSystem.Domain.Models.Models.Transactions;
public class SentToMeTransaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal TransferAmount { get; set; }
}
