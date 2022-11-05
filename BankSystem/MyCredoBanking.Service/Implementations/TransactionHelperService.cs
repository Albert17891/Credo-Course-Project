namespace MyCredoBanking.Service.Implementations;

using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;

public class TransactionHelperService : ITransactionHelperService
{
    private readonly IUserService _userService;
    private readonly IContextWrapper _contextWrapper;

    public TransactionHelperService(IUserService userService, IContextWrapper contextWrapper)
    {
        _userService = userService;
        _contextWrapper = contextWrapper;
    }
    public async Task<IList<UserAccountServiceModel>> GetAccounts(UserManager<AppUser> userManager, string userName)
    {
        var user = await userManager.FindByNameAsync(userName);
        var accounts = await _userService.GetAllAccount(user.Id);
        if (accounts.Count == 0)
        {
            accounts = null;
        }

        return accounts;
    }

    public async Task<IList<UserAccountServiceModel>> GetOtherAccounts(UserManager<AppUser> userManager, string userName,
        int firstAccountId)
    {
        var user = await userManager.FindByNameAsync(userName);

        var accounts = await _contextWrapper.userAccountRepository.GetAllOtherAccount(user.Id, firstAccountId);

        if (accounts.Count == 0)
        {
            accounts = null;
        }

        return accounts.Adapt<IList<UserAccountServiceModel>>();
    }

    public async Task<IList<UserAccountServiceModel>> GetAccoutsWithIdNumber(UserManager<AppUser> userManager,
        string userName, string IdNumber)
    {
        var user = await userManager.Users.Where(x => x.IdNumber == IdNumber).SingleOrDefaultAsync();

        if (user.UserName == userName)
        {
            user.UserAccounts = null;
            return user.UserAccounts.Adapt<IList<UserAccountServiceModel>>();
        }

        var accounts = await _userService.GetAllAccount(user.Id);

        if (accounts.Count == 0)
        {
            accounts = null;
        }

        return accounts.Adapt<IList<UserAccountServiceModel>>();
    }
}