using BankSystem.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace MyCredoBanking.Models.Request;

public class UserRequest
{
    public string Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string IdNumber { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    public List<CreditCardRequest> CreditCards { get; set; }
    public List<UserAccountRequest> UserAccounts { get; set; }
}
