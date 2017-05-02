using System;
using System.Collections.Generic;
using System.Linq;

namespace Quote.Core
{
    public class Finder : IFinder
    {
        private readonly IRepository _repository;
        private readonly ICompoundInterestCalculator _calculator;
       
        public Finder(IRepository repository)
        {
            _repository = repository;
            _calculator = new CompoundInterestCalculator();
        }

        public Finder(IRepository repository, ICompoundInterestCalculator calculator)
        {
            _repository = repository;
            _calculator = calculator;
        }

        public QuoteResult GetQuote(double amount)
        {
            var totalAccruedAmount = GetTotalAccruedAmount(amount, GetAvailableLenders(amount));
            return Convert.ToInt32(totalAccruedAmount) == 0
                ? null
                : new QuoteResult
                    {
                        Amount = Convert.ToInt32(amount),
                        Rate = Convert.ToDecimal(_calculator.Rate(amount, totalAccruedAmount, 12, 3)),
                        MonthlyRepayment = Convert.ToDecimal(totalAccruedAmount / (12 * 3)),
                        TotalRepayment = Convert.ToDecimal(totalAccruedAmount)
                    };
        }

        private List<Lender> GetAvailableLenders(double amount)
        {
            double sum = 0;
            var lenders = _repository.GetLenders()
                .OrderBy(l => l.Rate)
                .TakeWhile(x =>
                {
                    var temp = sum;
                    sum = sum + x.Available;
                    return temp < amount;
                }).ToList();

            var totalAvailable = lenders.Sum(l => l.Available);
            if (totalAvailable < amount)
            {
                lenders = new List<Lender>();
            }

            return lenders;
        }

        private double GetTotalAccruedAmount(double amount, List<Lender> lenders)
        {
            var currentAmount = amount;
            return lenders.Sum(v =>
            {
                var temp = currentAmount - v.Available;
                var available = temp < 0 ? currentAmount : v.Available;
                currentAmount = currentAmount - v.Available;
                return _calculator.AccruedAmount(available, v.Rate, 12, 3);
            });
        }

    }
}