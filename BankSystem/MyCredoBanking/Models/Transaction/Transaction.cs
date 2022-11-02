namespace MyCredoBanking.Models.Transaction;

public class Transaction
{
    public int ReceiverAccountId { get; set; }
    public int SenderAccountId { get; set; }
    public decimal Amount { get; set; }
}
