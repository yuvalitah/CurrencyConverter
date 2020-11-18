using System;

namespace CurrencyConverter
{
    public class ConsoleUI : IUIService
    {
        public string GetFilePathFromUser()
        {
            Console.WriteLine("Please enter the file path");
            return Console.ReadLine();
        }

        public void PrintExchangeResults(double[]? results)
        {
            if (results != null)
            {
                foreach (double result in results)
                {
                    Console.WriteLine(result);
                }
            }
        }

        public void PrintExceptionMessage(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
