using System.Text.Json.Serialization;

namespace Nextech_Coding_Assignment.Server.Models.AlphaVantage
{
    public class TimeIntervalJson
    {
        [JsonPropertyName("1. open")]
        public string open { get; set; }

        [JsonPropertyName("2. high")]
        public string high { get; set; }

        [JsonPropertyName("3. low")]
        public string low { get; set; }

        [JsonPropertyName("4. close")]
        public string close { get; set; }

        [JsonPropertyName("5. volume")]
        public string volume { get; set; }
    }

    public class TimeInterval
    {
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string close { get; set; }
        public string volume { get; set; }
    }
}