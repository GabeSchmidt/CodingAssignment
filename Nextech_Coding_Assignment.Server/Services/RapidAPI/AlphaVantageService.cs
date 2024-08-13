using AutoMapper;
using Nextech_Coding_Assignment.Server.Models.AlphaVantage;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Nextech_Coding_Assignment.Server.Services.RapidAPI
{
    public interface IAlphaVantageService
    {
        Task<List<BestMatch>> SearchByKeywords(string keywords);
        Task<Daily> GetDaily(string symbol);
        Task<NewsFeed> GetNewsFeed(string symbol);
    }

    public sealed class AlphaVantageService : IAlphaVantageService, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public AlphaVantageService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        /// <summary>
        ///  Search for specific symbols or companies
        /// </summary>
        /// <param name="keywords">A text string of your choice</param>
        /// <returns>best matches</returns>
        public async Task<List<BestMatch>> SearchByKeywords(string keywords)
        {
			try
			{
                List<BestMatch> retVal = new List<BestMatch>();

                SymbolSearch? results = await _httpClient.GetFromJsonAsync<SymbolSearch>(
                    $"query?keywords={keywords}&function=SYMBOL_SEARCH",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web)
                );

                if (results?.bestMatches != null)
                {
                    results.bestMatches = results.bestMatches
                        .Where(x => x.region.ToLower() == "united states")
                        .ToList();

                    retVal = _mapper.Map<List<BestMatch>>(results.bestMatches);
                }

                return retVal;
			}
			catch (Exception ex)
			{
                return null;
			}
        }
                
        /// <summary>
        /// raw (as-traded) daily time series
        /// </summary>
        /// <param name="symbol">The name of the equity of your choice</param>
        /// <returns>
        /// returns raw (as-traded) daily time series (date, daily open, daily high, daily low, daily close, daily volume)
        /// of the global equity specified
        /// </returns>
        public async Task<Daily> GetDaily(string symbol)
        {
            try
            {
                Daily results = new Daily();
                HttpResponseMessage response = await _httpClient.GetAsync(
                    $"query?symbol={symbol}&function=TIME_SERIES_DAILY"); //&outputsize=full
                string json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    JsonNode node = JsonNode.Parse(json);
                    var metaDataJson = JsonSerializer.Deserialize<DailyMetaDataJson>(node["Meta Data"]);
                    results.MetaData = _mapper.Map<DailyMetaData>(metaDataJson);

                    var intervalsJson = JsonSerializer.Deserialize<Dictionary<string, TimeIntervalJson>>(node[$"Time Series (Daily)"]);
                    results.Intervals = new Dictionary<string, TimeInterval>();

                    foreach (var intrvl in intervalsJson)
                    {
                        results.Intervals.Add(intrvl.Key, _mapper.Map<TimeInterval>(intrvl.Value));
                    }
                }
                
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Stock Market News for the Company searched
        /// </summary>
        /// <param name="symbol">The name of the equity of your choice</param>
        /// <returns>returns live and historical market news & sentiment data from a large & growing selection of premier news outlets around the world</returns>
        public async Task<NewsFeed> GetNewsFeed(string symbol)
        {
            try
            {
                NewsFeed results = new NewsFeed();
                HttpResponseMessage response = await _httpClient.GetAsync(
                    $"query?function=NEWS_SENTIMENT&tickers={symbol}&sort=LATEST&limit=20");
                string json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    results = JsonSerializer.Deserialize<NewsFeed>(json);
                }

                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
