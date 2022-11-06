namespace CredoReport.Service.Service;

using BankSystem.DataAccess.Abstractions;
using CredoReport.Service.Abstractions;

public class UserStatisticService : IUserStatisticService
{
	private readonly IContextWrapper _contextWrapper;

	public UserStatisticService(IContextWrapper contextWrapper)
	{
		_contextWrapper = contextWrapper;
	}

	public async Task<int> GetUsersQuantityService(double Id)
	{
		return await _contextWrapper.userRepository.GetUsersQuantity(Id);
	}
}