using BankSystem.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyCredoBanking.Models.Request;
using MyCredoBanking.Models.Response;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Implementations;
using MyCredoBanking.Service.Model;

namespace MyCredoBanking.Controllers;
[Authorize(Roles ="Operator")]
public class OperatorController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IOperatorService _operatorService;
    private readonly IUserService _userService;

    public OperatorController(UserManager<AppUser> userManager,IOperatorService operatorService,IUserService userService)
    {
        _userManager = userManager;
        _operatorService = operatorService;
        _userService = userService;
    }
    public async Task<IActionResult> Operator()
    {   
        var user =await _userManager.Users.Where(x=>x.UserName!="Operator").ToListAsync() ;
       
        return View(user.Adapt<IList<UserRequest>>());
    }

    [Route("CreditCard")]
    [HttpPost]
    public IActionResult CreditCard(CreditCardRequest request)
    {
       
        return View(request);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCreditCard(CreditCardRequest cardRequest)
    {
        await _operatorService.AddCardForAccount(cardRequest.Adapt<CreditCardServiceModel>());
        return RedirectToAction("Operator");
    }

    [Route("UserAccount")]
    [HttpGet("{Id}")]
    public IActionResult UserAccount(string Id)
    {
        return View(new UserAccountRequest() { UserId = Id });
    }

    [Route("CreateUserAccount")]
    [HttpPost]
    public async Task<IActionResult> CreateUserAccount(UserAccountRequest userAccountRequest)
    {
        if (ModelState.IsValid)
        {
            await _operatorService.AddBankAccountForUser(userAccountRequest.Adapt<UserAccountServiceModel>());
            return RedirectToAction("Operator");
        }


        return RedirectToAction("Error","Home");
    }

    [Route("GetUserCards")]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUserCards(string Id)
    {
        var cards = await _userService.GetAllCard(Id);
        return View(cards.Adapt<List<CreditCardResponse>>());
    }

    [Route("GetUserAccounts")]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUserAccounts(string Id)
    {
        var accounds = await _userService.GetAllAccount(Id);

        return View(accounds.Adapt<List<UserAccountRequest>>());
    }
}
