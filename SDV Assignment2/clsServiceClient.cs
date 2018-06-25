using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShopWinForm
{
    public static class clsServiceClient
    {
        internal async static Task<List<string>> GetCategoryNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/shop/GetCategoryNames/"));
        }
        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
           new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
        internal async static Task<double> GetTotalOrderPriceAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<double>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/shop/GetTotalOrderPrice/"));
        }

        internal async static Task<string> GetInstrumentName(string Name, string Type)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<string>
                (await lcHttpClient.GetStringAsync(string.Format("http://localhost:60064/api/shop/GetInstrumentName?Name={0}&Type={1}", Name, Type)));
        }

        internal async static Task<List<int>> GetOrdersAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<int>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/shop/GetOrders/"));
        }

        internal async static Task<string> InsertInstrumentAsync(clsAllInstrument prInstrument)
        {
            return await InsertOrUpdateAsync(prInstrument, "http://localhost:60064/api/shop/PostInstrument", "POST");
        }

        internal async static Task<string> UpdateInstrumentAsync(clsAllInstrument prInstrument)
        {
            return await InsertOrUpdateAsync(prInstrument, "http://localhost:60064/api/shop/PutInstrument", "PUT");
        }

        internal async static Task<string> InsertOrderAsync(clsOrders prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/shop/PostOrder", "POST");
        }

        internal async static Task<clsCategory> GetCategoryInstrumentsAsync(string prCategoryName)
        {
                using (HttpClient lcHttpClient = new HttpClient())
                    return JsonConvert.DeserializeObject<clsCategory>
                    (await lcHttpClient.GetStringAsync
                    ("http://localhost:60064/api/shop/GetCategoryInstruments?Name=" + prCategoryName));
        }
        internal async static Task<clsOrders> GetOrderDetailsAsync(int prOrderID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsOrders>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/shop/GetOrderDetails?OrderID=" + prOrderID));
        }

        internal async static Task<string> DeleteInstrumentAsync(clsAllInstrument clsAllInstrument)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
               ($"http://localhost:60064/api/shop/DeleteInstrument?prInstrumentID={clsAllInstrument.InstrumentID}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<string> DeleteOrderAsync(clsOrders clsOrders)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
               ($"http://localhost:60064/api/shop/DeleteOrder?prOrderID={clsOrders.OrderID}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
