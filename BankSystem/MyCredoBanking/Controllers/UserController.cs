using BankSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyCredoBanking.Controllers;
public class UserController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public UserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [Route("Index")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> GetMyCards()
    {
        //To Do
        return Ok();
    }

    public async Task<IActionResult> GetMyAccounts()
    {
        //To Do
        return Ok();
    }

  
}
