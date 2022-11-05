namespace MyCredoBanking.Models.Request;

using BankSystem.Domain.Models.Enum;
using MyCredoBanking.Infrastracture.Attributes;
using MyCredoBanking.Infrastracture.Resources;
using System.ComponentModel.DataAnnotations;

public class UserAccountRequest
{
    public int Id { get; set; }

    public string UserId { get; set; }
    
    [IbanValidation(ErrorMessage =ErrorMessage.Iban)]
    public string Iban { get; set; }

    [Required]
    [RegularExpression("^[1-9][0-9]*$",ErrorMessage=ErrorMessage.Amount)]
    public decimal Amount { get; set; }

    [Required]
    public Currency Currency { get; set; }
}