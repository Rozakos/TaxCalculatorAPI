using Microsoft.AspNetCore.Mvc;
using TaxCalculatorAPI.Services;

namespace TaxCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly TaxCalculatorService _taxCalculatorService;

        public CalculateController(TaxCalculatorService taxCalculatorService)
        {
            _taxCalculatorService = taxCalculatorService;
        }

        [HttpPost]
        public IActionResult CalculateTax([FromBody] TaxRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Country) || request.Price <= 0)
            {
                return BadRequest("Invalid input.");
            }

            string result = _taxCalculatorService.CalculatePrice(request.Country, request.Price);
            return Ok(new { message = result });
        }
    }

    public class TaxRequest
    {
        public string Country { get; set; }
        public double Price { get; set; }
    }
}
