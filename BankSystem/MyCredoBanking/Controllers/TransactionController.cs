using BankSystem.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCredoBanking.Infrastracture.ServiceCollectionExtensions;
using MyCredoBanking.Models.Request;
using MyCredoBanking.Models.Response;
using MyCredoBanking.Models.Transaction;
using MyCredoBanking.Service.Abstractions;

namespace MyCredoBanking.Controllers;

[Authorize(Roles ="User")]
public class TransactionController : Controller
{
    private readonly UserManager<AppUser> _userManger;
    private readonly IUserService _userService;

  
    public TransactionController(UserManager<AppUser> userManager,IUserService userService)
    {
        _userManger = userManager;
        _userService = userService;
    }

    [Route("SendToMe")]
    [HttpGet]
    public async Task<IActionResult> SendToMe()
    {
        var user = await _userManger.FindByNameAsync(User.Identity?.Name);
        var account = await _userService.GetAllAccount(user.Id);
        if (account is not null)
        {
            return View(account.Adapt<List<UserAccountResponse>>());
        }
        return View();
    }
  
    [HttpGet]
    public IActionResult GetIdNumber()
    {
        return View();
    }    

   
    [HttpPost]
    public async Task<IActionResult> GetReciverAccounts(IdNumberCheck idNumberCheck)
    {
        var user = await _userManger.Users.Where(x => x.IdNumber == idNumberCheck.IdNumber).FirstOrDefaultAsync();

        var accounts =await _userService.GetAllAccount(user.Id);
        if(accounts is not null)
        {
            return View(accounts.Adapt<List<UserAccountRequest>>());
        }
        //return View(accounts);
        return Ok();
    }

    [HttpGet]
    public IActionResult HowMuchMoney(int Id)
    {
        TempData["AccoundId"] = Id;
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetSenderAccounts(HowMuchMoney howMuch)
    {     

        TempData.Put("Amount", howMuch.Amount);

        var user =await _userManger.FindByNameAsync(User.Identity?.Name);
        var account =await _userService.GetAllAccount(user.Id);
        if(account is not null)
        {
            return View(account.Adapt<List<UserAccountRequest>>());
        }
        return Ok();//change it
    }

    [Route("SendToOther")]
    [HttpGet("{Id}")]
    public async Task<IActionResult> SendToOther(int Id)
    {

        var transaction = new Transaction()
        {
            ReceiverAccountId = (int)TempData["AccoundId"],
            SenderAccountId = Id,
            Amount = TempData.Get<decimal>("Amount")
        };

        return Ok();
    }
}
