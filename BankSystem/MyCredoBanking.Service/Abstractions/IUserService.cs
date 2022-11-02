

using MyCredoBanking.Service.Model;

namespace MyCredoBanking.Service.Abstractions;

public interface IUserService
{
    Task InnerTransaction();

    Task OuterTransaction();

    Task<IList<CreditCardServiceModel>> GetAllCard(string userId);

    Task<IList<UserAccountServiceModel>> GetAllAccount(string userId);

}
