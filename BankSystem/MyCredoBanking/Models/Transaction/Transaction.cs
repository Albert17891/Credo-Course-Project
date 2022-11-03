namespace MyCredoBanking.Models.Transaction;

public class Transaction
{
    public int SenderAccountId { get; set; }
    public int RecieverAccountId { get; set; }   
    public decimal Amount { get; set; }
}
