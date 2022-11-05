using CredoReport.Models.TransactionStastistic;
using Newtonsoft.Json;

namespace CredoReport.Service.Service;
public static class ChartService
{
    public static ChartJsServieModel GetChart(Dictionary<string, int> data)
    {
        var chartData = File.ReadAllText("Chart.Json");

        var chart = JsonConvert.DeserializeObject<ChartJs>(chartData);

        chart.data.labels = data.Keys.ToArray();

        foreach (var item in chart.data.datasets)
        {

            item.data = data.Values.ToArray();
        }

        var chartModel = new ChartJsServieModel
        {
            Chart = chart,
            ChartJson = JsonConvert.SerializeObject(chart, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            })
        };

        return chartModel;
    }
}

