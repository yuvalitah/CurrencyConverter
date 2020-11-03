using CurrencyConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CurrencyConverterTests
{
    [TestClass]
    public class CurrencyConverterTests
    {
        [TestMethod]
        public async Task CurerncyConverterTest()
        {
            const string filePathInput = @"C:\yuvalprojects\C#\CurrencyConverter\currency.txt";
            double[] expected = new double[] { 6.8169, 10.22535, 13.6338 };
            IUIService UIService = new ConsoleUI();
            ICurrencyExchange currencyExchange = new CurrencyExchange(UIService, filePathInput);
            double[] actual = await currencyExchange.CalculateCurrencyConvertion();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
