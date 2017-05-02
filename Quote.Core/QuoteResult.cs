namespace Quote.Core
{
    public class QuoteResult
    {
        public int Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public decimal TotalRepayment { get; set; }
    }
}