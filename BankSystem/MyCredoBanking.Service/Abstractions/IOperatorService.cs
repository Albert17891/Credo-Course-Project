using MyCredoBanking.Service.Model;

namespace MyCredoBanking.Service.Abstractions;

public interface IOperatorService
{
    Task AddBankAccountForUser(UserAccountServiceModel userAccount);
    Task AddCardForAccount(CreditCardServiceModel creditCard);
}