namespace MyCredoBanking.Controllers;

using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCredoBanking.Models.Request;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signinManager;
    private readonly ILogger<AccountController> _logger;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
        ,ILogger<AccountController> logger)
    {
        _userManager = userManager;
        _signinManager = signInManager;
        _logger = logger;
    }

    [Authorize(Roles ="Operator")]
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest register)
    {
        if (!ModelState.IsValid)
            return View();

        var user = new AppUser() { UserName=register.FirstName, IdNumber = register.IdNumber, BirthDate = register.BirthDate, FirstName = register.FirstName, LastName = register.LastName, Email = register.Email };
        var result = await _userManager.CreateAsync(user, register.Password);

        if (!result.Succeeded)
        {
            _logger.LogInformation("User Registered");

            ModelState.AddModelError("", "Error occurrences in Register Time");
            return View();
        }
        user.UserName = user.Email;  //UserName is Equals User Email

        await _userManager.AddToRoleAsync(user, RolesEnum.User.ToString());
        return RedirectToAction("Operator","operator");

    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        if (!ModelState.IsValid)
            return View();

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null)
        {
            var result = await _signinManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(user);
                if (role.First() == RolesEnum.Operator.ToString())
                    return RedirectToAction("Operator", "operator");

                return RedirectToAction("Index", "User");
            }
        }
        ModelState.AddModelError("", "Username or password is incorrect");

        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await _signinManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}