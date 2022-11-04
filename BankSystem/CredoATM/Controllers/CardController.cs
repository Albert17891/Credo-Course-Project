using AtmCredoBanking.Service.Abstractions;
using CredoATM.Infastructure.ServiceCollectionExtensions;
using CredoATM.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace CredoATM.Controllers;
public class CardController : Controller
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> CheckBalance()
    {
        var cart = HttpContext.Session.Get<CreditCardAtm>("CreditCart");
        var amount = await _cardService.ShowBalance(cart.UserAccountId);


        return View(new Balance { Amount=amount});
    }

    [HttpGet]
    public IActionResult ChangePin()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePin(ChangePin changePin)
    {
        var cart = HttpContext.Session.Get<CreditCardAtm>("CreditCart");
        await _cardService.ChangePin(cart.Id, changePin.Pin);

        return RedirectToAction("Index");
    }

    [Route("Withdraw")]
    [HttpGet]
    public IActionResult Withdraw()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Withdrawal(Balance balance)
    {
        var cart = HttpContext.Session.Get<CreditCardAtm>("CreditCart");
        await _cardService.WithDraw(cart.UserAccountId, balance.Amount);

        return RedirectToAction("Index");
    }
}
