namespace CredoReport.Service.Abstractions;
public interface IUserStatisticService
{
    Task<int> GetUsersQuantityService(int Id);

    Task<int> UsersRegisteredthisYearService();

    Task<int> UsersRegisteredLastOneYearService();

    Task<int> UsersRegisteredLast30DaysService();
}
