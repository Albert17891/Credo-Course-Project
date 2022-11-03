using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace MyCredoBanking.Infrastracture.ServiceCollectionExtensions;

public static class TempDataExtension
{
    public static void Put<T>( this ITempDataDictionary tempData,string key,T value) where T : struct
    {
        tempData[key] = JsonConvert.SerializeObject(value);
    }

    public static T Get<T>(this ITempDataDictionary tempData, string key) where T : struct
    {
        object o;
        tempData.TryGetValue(key, out o);
        var result= JsonConvert.DeserializeObject<T>((string)o);
        return result;
    }

}
