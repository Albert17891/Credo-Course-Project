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

	public Task<int> GetUsersQuantityService(int Id)
	{
		throw new NotImplementedException();
	}
}


	

	

