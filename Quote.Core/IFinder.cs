namespace Quote.Core
{
    public interface IFinder
    {
        QuoteResult GetQuote(double amount);
    }
}