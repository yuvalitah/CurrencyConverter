using System;

namespace CurrencyConverter
{
    public interface IUIService
    {
        string GetFilePathFromUser();
        void PrintExchangeResults(double[]? results);
        void PrintExceptionMessage(Exception ex);
    }
}
