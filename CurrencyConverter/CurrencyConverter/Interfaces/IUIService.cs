using System;

namespace CurrencyConverter
{
    public interface IUIService
    {
        public string GetFilePathFromUser();
        public void PrintExchangeResults(double[] results);
        public void PrintExceptionMessage(Exception ex);
    }
}
