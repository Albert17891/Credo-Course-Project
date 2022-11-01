using BankSystem.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCredoBanking.Models.Request;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;

namespace MyCredoBanking.Controllers;
//[Authorize]
public class OperatorController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IOperatorService _operatorService;

    public OperatorController(UserManager<AppUser> userManager,IOperatorService operatorService)
    {
        _userManager = userManager;
        _operatorService = operatorService;
    }
    public async Task<IActionResult> Operator()
    {
        var userListModel = new List<UserRequest>();
        
        var user =await _userManager.Users.Where(x=>x.UserName!="Operator").ToListAsync() ;
        foreach (var item in user)
        {
            var userModel = new UserRequest();
            userModel.Id = item.Id;
            userModel.FirstName = item.FirstName;
            userModel.LastName = item.LastName;
            userModel.IdNumber = item.IdNumber;
            userModel.BirthDate = item.BirthDate;
            userListModel.Add(userModel);
        }
        return View(userListModel);
    }

    [Route("CreditCard")]
    [HttpGet]//Check
    public IActionResult CreditCard(string Id)
    {
       
        return View(new CreditCardRequest { UserId=Id});
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
       await  _operatorService.AddBankAccountForUser(userAccountRequest.Adapt<UserAccountServiceModel>());

        return RedirectToAction("Operator");
    }

}
