using Microsoft.AspNetCore.Mvc;
using Nextech_Coding_Assignment.Server.Models.AlphaVantage;
using Nextech_Coding_Assignment.Server.Services.RapidAPI;

namespace Nextech_Coding_Assignment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlphaVantageController : ControllerBase
    {
        private readonly IAlphaVantageService _alphaVantageService;

        public AlphaVantageController(IAlphaVantageService alphaVantageService)
        {
            _alphaVantageService = alphaVantageService;
        }

        [HttpGet("SearchByKeywords/{keywords}")]
        public async Task<List<BestMatch>> SearchByKeywords(string keywords)
        {
            return await _alphaVantageService.SearchByKeywords(keywords);
        }

        [HttpGet("GetDaily/{symbol}")]
        public async Task<Daily?> GetDaily(string symbol)
        {
            return await _alphaVantageService.GetDaily(symbol);
        }

        [HttpGet("GetNewsFeed/{symbol}")]
        public async Task<NewsFeed> GetNewsFeed(string symbol)
        {
            return await _alphaVantageService.GetNewsFeed(symbol);
        }
    }
}
