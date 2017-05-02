using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Quote.Core;

namespace Quote.Tests
{
    [TestClass]
    public class FinderTests
    {
        private List<Lender> Lenders { get; set; }

        [TestInitialize]
        public void Init()
        {
            Lenders = new List<Lender>
            {
                new Lender {Name = "Bob", Rate = 0.075, Available = 640},
                new Lender {Name = "Jane", Rate = 0.069, Available = 480},
                new Lender {Name = "Fred", Rate = 0.071, Available = 520},
                new Lender {Name = "Mary", Rate = 0.104, Available = 170},
                new Lender {Name = "John", Rate = 0.081, Available = 320},
                new Lender {Name = "Dave", Rate = 0.074, Available = 140},
                new Lender {Name = "Angela", Rate = 0.071, Available = 60}
            };
        }


        [TestMethod]
        public void no_available_lenders_for_the_requested_amount_should_return_null()
        {
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(t => t.GetLenders()).Returns(Lenders);

            var finder = new Finder(mockRepository.Object);

            var quote = finder.GetQuote(2500);

            Assert.IsNull(quote);
        }

        [TestMethod]
        public void calculate_future_value()
        {
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(t => t.GetLenders()).Returns(Lenders);

            var finder = new Finder(mockRepository.Object);

            var quote = finder.GetQuote(1000);

            Assert.IsNotNull(quote);
        }
    }
}