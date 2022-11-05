namespace MyCredoBanking.Service.Abstractions;

using MyCredoBanking.Service.Model;

public interface IUserService
{
    Task<bool> Transaction(TransactionServiceModel transaction);

    Task<IList<CreditCardServiceModel>> GetAllCard(string userId);

    Task<IList<UserAccountServiceModel>> GetAllAccount(string userId);
}