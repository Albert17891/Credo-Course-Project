namespace MyCredoBanking.Controllers;

using BankSystem.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCredoBanking.Models.Request;
using MyCredoBanking.Models.Response;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;

[Authorize(Roles = "Operator")]
public class OperatorController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IOperatorService _operatorService;
    private readonly IUserService _userService;
    private readonly ILogger<OperatorController> _logger;

    public OperatorController(UserManager<AppUser> userManager, IOperatorService operatorService
        , IUserService userService
        ,ILogger<OperatorController> logger)
    {
        _userManager = userManager;
        _operatorService = operatorService;
        _userService = userService;
        _logger = logger;
    }
    public async Task<IActionResult> Operator()
    {
        var user = await _userManager.Users.Where(x => x.UserName != "Operator").ToListAsync();

        return View(user.Adapt<IList<UserResponse>>());
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

    [Route("CreateUserAccount")]
    [HttpGet("{Id}")]
    public IActionResult CreateUserAccount(string Id)
    {
        return View(new UserAccountRequest() { UserId = Id });
    }

    [Route("CreateUserAccount")]
    [HttpPost]
    public async Task<IActionResult> CreateUserAccount(UserAccountRequest userAccountRequest)
    {
        if (!ModelState.IsValid)
            return View(new UserAccountRequest() { UserId = userAccountRequest.UserId });

        await _operatorService.AddBankAccountForUser(userAccountRequest.Adapt<UserAccountServiceModel>());

        _logger.LogInformation("Create User Account");

        return RedirectToAction("Operator");


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