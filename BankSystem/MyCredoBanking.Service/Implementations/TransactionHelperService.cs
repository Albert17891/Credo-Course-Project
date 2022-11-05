namespace MyCredoBanking.Service.Implementations;

using BankSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;

public class TransactionHelperService : ITransactionHelperService
{
    private readonly IUserService _userService;

    public TransactionHelperService(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IList<UserAccountServiceModel>> GetAccounts(UserManager<AppUser> userManager, string userName)
    {
        var user = await userManager.FindByNameAsync(userName);
        var accounts = await _userService.GetAllAccount(user.Id);

        return accounts;
    }

    public async Task<IList<UserAccountServiceModel>> GetAccounts(UserManager<AppUser> userManager, string userName,
        int firstAccountId)
    {
        var user = await userManager.FindByNameAsync(userName);
        var allAccounts = await _userService.GetAllAccount(user.Id);

        var accounts = await allAccounts.Where(x => x.Id != firstAccountId).AsQueryable().ToListAsync();

        return accounts;
    }

    public async Task<IList<UserAccountServiceModel>> GetAccoutsWithIdNumber(UserManager<AppUser> userManager, string IdNumber)
    {
        var user = await userManager.Users.Where(x => x.IdNumber == IdNumber).SingleOrDefaultAsync();

        var accounts = await _userService.GetAllAccount(user.Id);

        return accounts;
    }
}