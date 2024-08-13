using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Nextech_Coding_Assignment.Server.Models.AlphaVantage
{
    public class SymbolSearch
    {
        [JsonPropertyName("bestMatches")]
        public List<BestMatchJson> bestMatches { get; set; }
    }

    public class BestMatchJson
    {
        [JsonPropertyName("1. symbol")]
        public string symbol { get; set; }

        [JsonPropertyName("2. name")]
        public string name { get; set; }

        [JsonPropertyName("3. type")]
        public string type { get; set; }

        [JsonPropertyName("4. region")]
        public string region { get; set; }

        [JsonPropertyName("5. marketOpen")]
        public string marketOpen { get; set; }

        [JsonPropertyName("6. marketClose")]
        public string marketClose { get; set; }

        [JsonPropertyName("7. timezone")]
        public string timezone { get; set; }

        [JsonPropertyName("8. currency")]
        public string currency { get; set; }

        [JsonPropertyName("9. matchScore")]
        public string matchScore { get; set; }
    }

    public class BestMatch
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string region { get; set; }
        public string marketOpen { get; set; }
        public string marketClose { get; set; }
        public string timezone { get; set; }
        public string currency { get; set; }
        public string matchScore { get; set; }
    }

}
