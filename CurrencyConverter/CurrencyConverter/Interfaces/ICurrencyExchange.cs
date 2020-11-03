using System.Threading.Tasks;

namespace CurrencyConverter
{
    public interface ICurrencyExchange
    {
        IUIService UIService { get; }
        string[] Lines { get; }
        public string[] GetAllLinesFromFile();
        public Task<double> GetExchangeRate();
        public Task<double[]?> CalculateCurrencyConvertion();
    }
}
