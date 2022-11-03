using MyCredoBanking.Service.nbgApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyCredoBanking.Service.nbgApi;

public static class Client
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public static Task<ResponseModel> GetRates()
    {
        var URL = $"https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/ka/json/?date={DateTime.Now.ToString("yyyy/MM/dd")}";

        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(URL)
        };
        var response = _httpClient.SendAsync(request).ConfigureAwait(false);

        var result = response.GetAwaiter().GetResult();

        if (result.StatusCode == HttpStatusCode.OK)
        {
            var responseData = result.Content.ReadAsStringAsync();

            var returnResult = JsonSerializer.Deserialize<ResponseModel>(responseData.Result);

            return Task.FromResult(returnResult);

        }
        return Task.FromResult<ResponseModel>(null);

    }
}
