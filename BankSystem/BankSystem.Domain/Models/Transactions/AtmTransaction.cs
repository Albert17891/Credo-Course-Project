namespace BankSystem.Domain.Models.Transactions;
public class AtmTransaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal TransferAmount { get; set; }
    public double TransferFee { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal TransactionIncome { get; set; }
}
