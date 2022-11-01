using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCredoBanking.Models.Request;

namespace MyCredoBanking.Controllers;
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signinManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signinManager = signInManager;
    }

    //[Authorize(Roles ="Operator")]
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
            ModelState.AddModelError("", "Error occurrences in Register Time");
            return View();
        }
        user.UserName = user.Id;  //UserName is Equals User Id

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
