using NUnit.Framework;
using TaxCalculatorAPI.Services;

namespace TaxCalculator.Tests.Services
{
    public class TaxCalculatorServiceTests
    {
        private TaxCalculatorService _taxCalculatorService;

        [SetUp]
        public void Setup()
        {
            _taxCalculatorService = new TaxCalculatorService();
        }

        [Test]
        [TestCase("Germany", 100, 84.03)]  // Passing country name as string
        [TestCase("Germany", 50, 42.02)]   // Adjust country names and prices as needed
        [TestCase("France", 200, 166.67)]  // Another example with France
        public void CalculatePrice_ShouldReturnCorrectValue(string country, double price, double expectedResult)
        {
            var result = _taxCalculatorService.CalculatePrice(country, price);  // Using the CalculateTax method
            Assert.That(result, Does.Contain(expectedResult.ToString()));  // Verifying that the result contains the expected price
        }
    }
}
