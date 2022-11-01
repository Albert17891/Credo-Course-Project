

namespace MyCredoBanking.Service.Abstractions;

public interface IUserService
{
    Task InnerTransaction();

    Task OuterTransaction();

    Task<IList<string>> GetAllCard(string userId);

    Task<IList<string>> GetAllAccount(string userId);

}
