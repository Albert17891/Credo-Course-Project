namespace BankSystem.Domain.Models;

using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string IdNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public DateTime RegisterTime { get; set; } = DateTime.Now;

    public IList<Transactions> Transactions { get; set; }

    public IList<CreditCard> CreditCards { get; set; }

    public IList<UserAccount> UserAccounts { get; set; }
}