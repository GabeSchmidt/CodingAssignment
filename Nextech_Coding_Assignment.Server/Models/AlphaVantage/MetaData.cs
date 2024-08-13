namespace Nextech_Coding_Assignment.Server.Models.AlphaVantage
{
    public class MetaData
    {
        public string Information { get; set; }
        public string Symbol { get; set; }
        public string LastRefreshed { get; set; }
        public string TimeZone { get; set; }
    }

    public class DailyMetaData : MetaData
    {
        public string OutputSize { get; set; }
    }

    public class IntraDayMetaData : DailyMetaData
    {
        public string Interval { get; set; }
    }

}
