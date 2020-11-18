using System.Threading.Tasks;

namespace CurrencyConverter
{
    public interface ICurrencyExchange
    {
        IUIService UIService { get; }
        string[] Lines { get; }
        Task<double> GetExchangeRateAsync();
        Task<double[]?> CalculateCurrencyConvertionAsync();
    }
}
