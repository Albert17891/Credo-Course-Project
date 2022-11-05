namespace MyCredoBanking.Service.nbgApi;

using MyCredoBanking.Service.nbgApi.Models;
using System.Net;
using System.Text.Json;


public static class Client
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public static decimal GetRate(string currency)
    {
        var URL = $"https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/ka/json/?date={DateTime.Now.ToString("yyyy/MM/dd")}";

        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(URL)
        };
        var response = _httpClient.SendAsync(request).ConfigureAwait(false);

        var result = response.GetAwaiter().GetResult();

        if (result.StatusCode == HttpStatusCode.OK) throw new OperationCanceledException("HTTP request was not successful");

        var responseData = result.Content.ReadAsStringAsync();

        // ყველა ვალუტა.
        var currencies = JsonSerializer.Deserialize<IList<ResponseModel>>(responseData.Result)
            ?? throw new NullReferenceException("Curencys deserialize problem");

        // საჭირო ვალუტის ამოღება.
        var returnResult = currencies[0].currencies.Where(x => x.code == currency).FirstOrDefault()
            ?? throw new NullReferenceException("Curency did not matched."); ;

        return returnResult.rate;
    }
}