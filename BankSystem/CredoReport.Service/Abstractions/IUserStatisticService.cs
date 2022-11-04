namespace CredoReport.Service.Abstractions;
public interface IUserStatisticService
{
    Task<int> GetUsersFromThisYearService();
    Task<int> GetUsersFromOneYearService();
    Task<int> GetUsersOneMonthService();
}
