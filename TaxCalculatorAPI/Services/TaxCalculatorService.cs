namespace TaxCalculatorAPI.Services
{
    public class TaxCalculatorService
    {
        public double CalculatePrice(double price, double vatRate)
        {
            double vatDecimal = vatRate / 100;
            return price / (1 + vatDecimal);  // price without VAT
        }
    }
}
