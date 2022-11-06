namespace MyCredoBanking.Controllers;

using BankSystem.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCredoBanking.Models.Request;
using MyCredoBanking.Models.Response;
using MyCredoBanking.Service.Abstractions;


[Authorize(Roles = "User")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly UserManager<AppUser> _userManager;

    public UserController(UserManager<AppUser> userManager, IUserService userService)
    {
        _userService = userService;
        _userManager = userManager;
    }

    [Route("Index")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetMyCards()
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name);

        var cards = await _userService.GetAllCard(user.Id);
        return View(cards.Adapt<List<CreditCardResponse>>());
    }

    [HttpGet]
    public async Task<IActionResult> GetMyAccounts()
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name);

        var accounds = await _userService.GetAllAccount(user.Id);
        return View(accounds.Adapt<List<UserAccountRequest>>());
    }
}