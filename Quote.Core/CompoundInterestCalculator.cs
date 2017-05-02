using System;

namespace Quote.Core
{
    public class CompoundInterestCalculator : ICompoundInterestCalculator
    {
        public double AccruedAmount(double p, double r, int n, double t)
        {
            return p * Math.Pow(1 + r / n, n * t);
        }

        public double Rate(double p, double a, int n, double t)
        {
            return n * (Math.Pow((a/p), (1/(n*t))) - 1) * 100;
        }
    }
}