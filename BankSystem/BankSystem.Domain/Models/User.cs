namespace BankSystem.Domain.Models;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<CreditCard> CreditCards { get; set; }
    public List<UserAccount> UserAccounts { get; set; }
}