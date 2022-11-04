using BankSystem.DataAccess.Abstractions;
using BankSystem.DataAccess.Services;
using CredoReport.Service.Abstractions;

namespace CredoReport.Service.Service;
public class UserStatisticService:IUserStatisticService
{
	private readonly IContextWrapper _contextWrapper;

	public UserStatisticService(IContextWrapper contextWrapper)
	{
		_contextWrapper = contextWrapper;
	}

	public async Task<int> GetUsersOneMonthService()
	{
		return await _contextWrapper.userRepository.GetUsersOfOneMonth();
	}

	public async Task<int> GetUsersFromOneYearService()
	{
        return await _contextWrapper.userRepository.GetUsersOfOneYear();
    }
    public async Task<int> GetUsersFromThisYearService()
    {
        return await _contextWrapper.userRepository.GetUsersOfThisYear();
    }
}


	

	

