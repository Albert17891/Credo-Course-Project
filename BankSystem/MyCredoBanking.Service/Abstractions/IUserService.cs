using MyCredoBanking.Service.Model;

namespace MyCredoBanking.Service.Abstractions;

public interface IUserService
{
    Task<bool> Transaction(TransactionServiceModel transaction);

    Task<IList<CreditCardServiceModel>> GetAllCard(string userId);

    Task<IList<UserAccountServiceModel>> GetAllAccount(string userId);

}
