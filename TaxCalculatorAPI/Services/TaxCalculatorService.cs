using System.Collections.Generic;

namespace TaxCalculatorAPI.Services
{
    public class TaxCalculatorService
    {
        // All EU countries and their VAT rates
        private Dictionary<string, double> euVatRates = new Dictionary<string, double>
        {
            {"Austria", 20.0},
            {"Belgium", 21.0},
            {"Bulgaria", 20.0},
            {"Croatia", 25.0},
            {"Cyprus", 19.0},
            {"Czech Republic", 21.0},
            {"Denmark", 25.0},
            {"Estonia", 20.0},
            {"Finland", 24.0},
            {"France", 20.0},
            {"Germany", 19.0},
            {"Greece", 24.0},
            {"Hungary", 27.0},
            {"Ireland", 23.0},
            {"Italy", 22.0},
            {"Latvia", 21.0},
            {"Lithuania", 21.0},
            {"Luxembourg", 17.0},
            {"Malta", 18.0},
            {"Netherlands", 21.0},
            {"Poland", 23.0},
            {"Portugal", 23.0},
            {"Romania", 19.0},
            {"Slovakia", 20.0},
            {"Slovenia", 22.0},
            {"Spain", 21.0},
            {"Sweden", 25.0}
        };

        public string CalculatePrice(string country, double price)
        {
            if (!euVatRates.TryGetValue(country, out double vatRate))
            {
                return $"VAT rate for {country} not found.";
            }

            double finalPrice = price / (1 + vatRate / 100);
            return $"The {vatRate}% tax of {country} will be reimbursed. Final price: {finalPrice:F2} euros.";
        }
    }
}
