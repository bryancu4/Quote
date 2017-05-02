using System;
using System.Globalization;
using System.Threading;
using Quote.Core;

namespace Quote
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetCurrentCulture();

            if (IsValidateInputs(args))
            {
                var finder = new Finder(new CsvRepository(args[0]));
                var quote = finder.GetQuote(Convert.ToDouble(args[1]));

                if (quote == null)
                {
                    Console.WriteLine("Sorry, it is not possible to provide a quote at that time");
                }
                else
                {
                    Console.WriteLine("Requested amount: {0}", quote.Amount);
                    Console.WriteLine("Rate: {0}%", Math.Round(quote.Rate, 1));
                    Console.WriteLine("Monthly repayment: {0:C}", quote.MonthlyRepayment);
                    Console.WriteLine("Total repayment: {0:C}", quote.TotalRepayment);
                }
            }
        }

        static bool IsValidateInputs(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("quote.exe [market_file.csv] [loan_amount]");
                return false;
            }

            int amount;
            if (!int.TryParse(args[1], out amount))
            {
                Console.WriteLine("amount is not a number");
                return false;
            }

            if (amount % 100 != 0 || amount < 100 || amount > 15000)
            {
                Console.WriteLine("to request a loan of any £100 increment between £1000 and £15000 inclusive");
                return false;
            }
            
            return true;
        }

        static void SetCurrentCulture()
        {
            var gb = CultureInfo.GetCultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = gb;
            Thread.CurrentThread.CurrentUICulture = gb;
        }
    }
}
