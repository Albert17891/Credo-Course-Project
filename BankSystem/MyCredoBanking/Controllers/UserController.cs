using BankSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyCredoBanking.Controllers;
public class UserController : Controller
{
  

    public UserController()
    {
        
    }

    [Route("Index")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }


    public async Task<IActionResult> GetMyCards()
    {
       
        return Ok();
    }

    public async Task<IActionResult> GetMyAccounts()
    {
        //To Do
        return Ok();
    }

  
}
