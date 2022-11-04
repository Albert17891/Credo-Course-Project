using BankSystem.DataAccess.Abstractions;
using CredoReport.Service.Abstractions;

namespace CredoReport.Service.Service;
public class UserStatisticService:IUserStatisticService
{
	private readonly IContextWrapper _contextWrapper;

	public UserStatisticService(IContextWrapper contextWrapper)
	{
		_contextWrapper = contextWrapper;
	}

	public async Task Test()
	{
		
	}
}
