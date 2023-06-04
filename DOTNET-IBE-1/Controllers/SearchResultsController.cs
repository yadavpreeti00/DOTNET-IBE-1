using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_IBE_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchResultsController : ControllerBase
    {
        private readonly IPromotionsService _promotionsService;
        private readonly ISearchResultsService _searchResultsService;
        public SearchResultsController(IPromotionsService promotionsService, ISearchResultsService searchResultsService)
        {
            _promotionsService = promotionsService;
            _searchResultsService = searchResultsService;
        }

        [HttpPost]
        [Route("/SearchResults")]
        public async Task<IActionResult> GetSearchResult(AvailableRoomRequestModel availableRoomRequest)
        {
            var response = await _searchResultsService.GetSearchResults(availableRoomRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("/DefaultPromotions")]
        public async Task<IActionResult> GetDefaultPromotions(PromotionRequestModel promotionRequest)
        {
            var response = await _promotionsService.GetDefaultPromotions(promotionRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("/CustomPromotions")]
        public async Task<IActionResult> GetCustomPromotions(PromotionRequestModel promotionRequest)
        {
            var response = await _promotionsService.GetCustomPromotion(promotionRequest);
            return Ok(response);
        }
    }
}
