using BankSystem.Domain.Models.Transactions;

namespace BankSystem.Domain.Models.Transaction;
public class SendToUtherTransaction
{
    public int Id { get; set; }
    public int SenderUserId { get; set; }
    public int ReceiverUserId { get; set; }
    public decimal TransferFee { get; set; }
    public decimal TransferAmount { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal TransactionIncome { get; set; }

    public ExchangeTransaction ExchangeTransaction { get; set; }
}
