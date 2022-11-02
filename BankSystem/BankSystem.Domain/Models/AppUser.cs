using Microsoft.AspNetCore.Identity;

namespace BankSystem.Domain.Models;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string IdNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public IList<Transactions> Transactions { get; set; }

    public IList<CreditCard> CreditCards { get; set; }

    public IList<UserAccount> UserAccounts { get; set; }
}