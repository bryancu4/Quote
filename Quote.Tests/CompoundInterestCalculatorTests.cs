using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quote.Core;

namespace Quote.Tests
{
    [TestClass]
    public class CompoundInterestCalculatorTests
    {
        [TestMethod]
        public void calculate_accrued_amount()
        {
            var calculator = new CompoundInterestCalculator();
            var fv = calculator.AccruedAmount(1000, 0.07, 12, 3);

            Assert.AreEqual(fv, 1232.92, 0.009);
        }

        [TestMethod]
        public void calculate_rate()
        {
            var calculator = new CompoundInterestCalculator();
            var r = calculator.Rate(1000, 1233.07, 12, 3);

            Assert.AreEqual(r, 7.0, 0.01);
        }
    }
}