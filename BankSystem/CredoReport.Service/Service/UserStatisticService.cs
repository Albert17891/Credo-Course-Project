namespace CredoReport.Service.Service;

using BankSystem.DataAccess.Abstractions;
using CredoReport.Service.Abstractions;

public class UserStatisticService:IUserStatisticService
{
	private readonly IContextWrapper _contextWrapper;

	public UserStatisticService(IContextWrapper contextWrapper)
	{
		_contextWrapper = contextWrapper;
	}	

	public async Task<int> GetUsersQuantityService(int Id)
	{
		return await _contextWrapper.userRepository.GetUsersQuantity(Id);
	}

    public async Task<int> UsersRegisteredLast30DaysService()
    {
		return await _contextWrapper.userRepository.UsersRegisteredLast30Days();
	}

	public async Task<int> UsersRegisteredLastOneYearService()
    {
		return await _contextWrapper.userRepository.UsersRegisteredLastOneYear();
	}

	public async Task<int> UsersRegisteredthisYearService()
    {
		return await _contextWrapper.userRepository.UsersRegisteredthisYear();
	}
}