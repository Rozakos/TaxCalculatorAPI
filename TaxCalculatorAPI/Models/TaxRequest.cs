namespace TaxCalculatorAPI.Models
{
    public class TaxRequest
    {
        public string Country { get; set; }
        public double Price { get; set; }
        public double VatRate { get; set; }
    }
}
