using DOTNET_IBE_1.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_IBE_1.Controllers
{
    [ApiController]
    public class RateController : Controller
    {
        private readonly IRateService _rateService;
        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        [Route("/Get/MinimumRates")]
        public async Task<IActionResult> GetMinimumRateForDay()
        {
            var response = await _rateService.GetMinimumRateDateMapping();
            return Ok(response);
        }
    }
}
