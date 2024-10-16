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
        [TestCase(100, 19, 84.03)]
        [TestCase(50, 19, 42.02)]
        [TestCase(200, 20, 166.67)]
        public void CalculatePrice_ShouldReturnCorrectValue(double price, double vatRate, double expectedResult)
        {
            var result = _taxCalculatorService.CalculatePrice(price, vatRate);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.01));
        }
    }
}
