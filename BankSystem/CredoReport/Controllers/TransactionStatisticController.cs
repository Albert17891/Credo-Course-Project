using CredoReport.Models.TransactionStastistic;
using Microsoft.AspNetCore.Mvc;

namespace CredoReport.Controllers;
public class TransactionStatisticController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("QuantityTransaction")]
    [HttpGet("quantity")]
    public async Task<IActionResult> QuantityTransaction(int quantity)
    {

        if (quantity == 30)
        {
          
            return View();
        }
        else if (quantity == 60)
        {
            return View();
        }
        else
        {
            return View();
        }
       
    }
   [Route("TransactionFeeQuantity")]
    [HttpGet("Id")]
    public async Task<IActionResult> TransactionFeeQuantity(int Id)
    {
      
        if(Id==30)
        {
            var transFee = new TransactionFee() { QuantityGel = 120, QuantityUsd = 10, QuantityEuro = 30 };
            return View(transFee);
        }
        else if(Id==60)
        {
            return View();
        }
        else
        {
            return View();
        }
        return Ok();
    }

    public async Task<IActionResult> AverageTransactionFee()
    {
        


        return View();

    }

    public async Task<IActionResult> AtmMoneyQuantity()
    {
        return View();
    }

}
