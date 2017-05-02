namespace Quote.Core
{
    public interface ICompoundInterestCalculator
    {
        double AccruedAmount(double p, double r, int n, double t);
        double Rate(double p, double a, int n, double t);
    }
}