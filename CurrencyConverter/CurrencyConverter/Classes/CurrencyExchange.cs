using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class CurrencyExchange : ICurrencyExchange
    {
        public IUIService UIService { get; }
        public string[] Lines { get; }
        public string FilePath { get; }
        public CurrencyExchange(IUIService uiService, string filePath)
        {
            UIService = uiService;
            FilePath = filePath;
            Lines = GetAllLinesFromFile();
        }

        public string[] GetAllLinesFromFile()
        {
            return File.ReadAllLines(FilePath);
        }

        public async Task<double> GetExchangeRate()
        {
            string currencies = $"{Lines[0].ToUpper()}_{Lines[1].ToUpper()}";
            string ApiAddress = $"https://free.currconv.com/api/v7/convert?q={currencies}&compact=ultra&apiKey=a1d13fa9f3dde093ff64";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(ApiAddress);
            JObject result = JObject.Parse(await response.Content.ReadAsStringAsync());
            double exchangeRate = Convert.ToDouble(result[currencies]);
            return exchangeRate;
        }

#nullable enable
        public async Task<double[]?> CalculateCurrencyConvertion()
        {

            double[]? convertedValues = new double[Lines.Length - 2];
            double exchangeRate = await GetExchangeRate();
            for (int i = 2; i < Lines.Length; i++)
            {
                convertedValues[i - 2] = Convert.ToDouble(Lines[i]) * exchangeRate;
            }
            return convertedValues;
        }
#nullable disable
    }
}
