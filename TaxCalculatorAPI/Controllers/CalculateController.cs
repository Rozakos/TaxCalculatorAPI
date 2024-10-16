using Microsoft.AspNetCore.Mvc;
using TaxCalculatorAPI.Models;
using TaxCalculatorAPI.Services;

namespace TaxCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly TaxCalculatorService _taxService;

        public CalculateController(TaxCalculatorService taxService)
        {
            _taxService = taxService;
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] TaxRequest request)
        {
            var result = _taxService.CalculatePrice(request.Price, request.VatRate);
            return Ok(new { message = $"The {request.VatRate}% tax of {request.Country} will be reimbursed. Final price: {result:F2} euros." });
        }
    }
}
