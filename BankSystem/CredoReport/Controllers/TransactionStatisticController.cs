namespace CredoReport.Controllers;

using CredoReport.Models.TransactionStastistic;
using CredoReport.Service.Abstractions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Route("TransactionStatistic")]
public class TransactionStatisticController : Controller
{
    private readonly ITransactionStatisticService _service;

    public TransactionStatisticController(ITransactionStatisticService service)
    {
        _service = service;
    }

    [Route("Index")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [Route("QuantityTransaction")]
    [HttpGet("choseType")]
    public async Task<IActionResult> QuantityTransaction(int choseType)
    {
        var result = await _service.GetTransactionsQuantityService(choseType);
        return View(new TransactionQuantity { Quantity = result });
    }
    [Route("TransactionFeeQuantity")]
    [HttpGet("Id")]
    public async Task<IActionResult> TransactionFeeQuantity(int Id)
    {
        var fee = await _service.GetTotalIncomeService(Id);
        return View(fee.Adapt<TransactionFee>());
    }

    [Route("AverageTransactionFee")]
    [HttpGet]
    public async Task<IActionResult> AverageTransactionFee()
    {
        var averageFee = await _service.GetAvgIncomeService();
        return View(averageFee.Adapt<TransactionFee>());
    }

    [Route("AtmMoneyQuantity")]
    [HttpGet]
    public async Task<IActionResult> AtmMoneyQuantity()
    {
        var result = await _service.GetWithdrawTotalService();
        return View(new MoneyQuantity { Quantity = result });
    }
    /// <summary>
    /// ///////////////////////////
    /// </summary>
    /// <returns></returns
    /// 
    [Route("ChartIndex")]
    [HttpGet]
    public IActionResult ChartIndex()
    {
        var chartData = @"
            {
                type: 'bar',
                responsive: true,
                data:
                {
                    labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
                    datasets: [{
                        label: '# of Votes',
                        data: [12, 19, 3, 5, 2, 3],
                        backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)'
                            ],
                        borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                            ],
                        borderWidth: 1
                    }]
                },
                options:
                {
                    scales:
                    {
                        yAxes: [{
                            ticks:
                            {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            }";

        var chart = JsonConvert.DeserializeObject<ChartJs>(chartData);

        var chartModel = new ChartJsViewModel
        {
            Chart = chart,
            ChartJson = JsonConvert.SerializeObject(chart, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            })
        };

        return View(chartModel);
    }
}
    


