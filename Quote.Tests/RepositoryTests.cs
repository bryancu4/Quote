using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quote.Core;

namespace Quote.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void load_lenders_from_a_csv_file()
        {
            var location = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\market.csv";

            var repository = new CsvRepository(location);
            var lenders = repository.GetLenders();

            Assert.IsTrue(lenders.Any());
        }

        [TestMethod]
        public void invalid_csv_file_location_should_have_empty_lenders()
        {
            var location = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\doesnotexists.csv";

            var repository = new CsvRepository(location);
            var lenders = repository.GetLenders();

            Assert.IsFalse(lenders.Any());
        }
    }
}
