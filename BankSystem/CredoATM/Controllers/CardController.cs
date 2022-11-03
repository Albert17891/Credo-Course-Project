using CredoATM.Infastructure.ServiceCollectionExtensions;
using CredoATM.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyCredoBanking.Service.Abstractions;

namespace CredoATM.Controllers;
public class CardController : Controller
{
    private readonly IUserService _userService;

    public CardController(IUserService userService)
    {
        _userService = userService;
    }
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> CheckBalance()
    {
        var cart = HttpContext.Session.Get<CreditCardResponse>("CreditCart");
        var account =await _userService.GetAccountById(cart.UserAccountId);    
        
       

        return View(account.Adapt<Balance>());
    }

    [HttpGet]
    public IActionResult ChangePin()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePin(ChangePin pin)
    {

        return View();
    }

    [Route("Withdrawal")]
    [HttpGet]
    public IActionResult Withdrawal()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Withdrawal(Balance balance)
    {
        return Ok();
    }
}
