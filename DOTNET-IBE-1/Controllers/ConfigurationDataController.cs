using DOTNET_IBE_1.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_IBE_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationDataController : ControllerBase
    {
        private readonly IConfigurationDataService _configurationDataService;
        public ConfigurationDataController(IConfigurationDataService configurationDataService)
        {
            _configurationDataService = configurationDataService;
        }

        [HttpGet]
        [Route("/LandingPage")]
        public async Task<IActionResult> GetLandingPageConfiguration()
        {
            var response = await _configurationDataService.GetLandingPageConfigurationData();
            return Ok(response);
        }

        [HttpGet]
        [Route("/RoomResultsPage")]
        public async Task<IActionResult> GetRoomResultPageConfiguration()
        {
            var response = await _configurationDataService.GetRoomResultsPageConfigurationData();
            return Ok(response);
        }

        [HttpGet]
        [Route("/CheckoutPage")]
        public async Task<IActionResult> GetCheckoutPageConfiguration()
        {
            var response = await _configurationDataService.GetCheckoutPageConfigurationData();
            return Ok(response);
        }
    }
}
