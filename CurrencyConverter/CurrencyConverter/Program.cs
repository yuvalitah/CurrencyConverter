using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IUIService UIService = new ConsoleUI();
            string filePath = UIService.GetFilePathFromUser();
            ICurrencyExchange currencyExchange = new CurrencyExchange(UIService, filePath);
            try
            {
                double[]? currencyResults = await currencyExchange.CalculateCurrencyConvertionAsync();
                UIService.PrintExchangeResults(currencyResults);
            }
            catch (HttpRequestException ex)
            {
                UIService.PrintExceptionMessage(ex);
            }
            catch (JsonReaderException ex)
            {
                UIService.PrintExceptionMessage(ex);
            }
        }
    }
}
