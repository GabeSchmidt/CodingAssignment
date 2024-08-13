using System.Text.Json.Serialization;

namespace Nextech_Coding_Assignment.Server.Models.AlphaVantage
{
    public class Daily
    {
        public DailyMetaData MetaData { get; set; }

        public Dictionary<string, TimeInterval> Intervals { get; set; }
    }

    public class DailyJson
    {
        [JsonPropertyName("Meta Data")]
        public DailyMetaDataJson MetaDataJson { get; set; }

        public Dictionary<string, TimeIntervalJson> IntervalsJson { get; set; }
    }

    public class DailyMetaDataJson
    {
        [JsonPropertyName("1. Information")]
        public string Information { get; set; }

        [JsonPropertyName("2. Symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("3. Last Refreshed")]
        public string LastRefreshed { get; set; }

        [JsonPropertyName("4. Output Size")]
        public string OutputSize { get; set; }

        [JsonPropertyName("5. Time Zone")]
        public string TimeZone { get; set; }
    }
}
