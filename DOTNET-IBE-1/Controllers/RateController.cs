using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_IBE_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;
        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        [Route("/MinimumRates")]
        public async Task<IActionResult> GetMinimumRateForDay()
        {
            var response = await _rateService.GetMinimumRateDateMapping();
            return Ok(response);
        }

        [HttpPost]
        [Route("/PriceBreakDown")]
        public async Task<IActionResult> GetRateBreakDown(PriceBreakdownRequestModel priceBreakdownRequest)
        {
            var response = await _rateService.GetPriceBreakDown(priceBreakdownRequest);
            return Ok(response);

        }
    }
}
