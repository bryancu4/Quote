using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quote.Core;

namespace Quote.Tests
{
    [TestClass]
    public class AppTests
    {
        [TestMethod]
        public void load_lenders_from_a_csv_file()
        {
            Quote.Program.Main(new[] {"", ""});
        }
    }
}