namespace MyCredoBanking.Service.Abstractions;

using MyCredoBanking.Service.Model;

public interface IOperatorService
{
    Task AddBankAccountForUser(UserAccountServiceModel userAccount);
    Task AddCardForAccount(CreditCardServiceModel creditCard);
}