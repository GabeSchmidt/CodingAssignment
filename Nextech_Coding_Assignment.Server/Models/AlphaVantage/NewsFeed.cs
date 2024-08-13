namespace Nextech_Coding_Assignment.Server.Models.AlphaVantage
{
    public class NewsFeed
    {
        public string items { get; set; }
        public string sentiment_score_definition { get; set; }
        public string relevance_score_definition { get; set; }
        public List<Feed> feed { get; set; }
    }

    public class Feed
    {
        public string title { get; set; }
        public string url { get; set; }
        public string time_published { get; set; }
        public List<string> authors { get; set; }
        public string summary { get; set; }
        public string banner_image { get; set; }
        public string source { get; set; }
        public string category_within_source { get; set; }
        public string source_domain { get; set; }
        public List<Topic> topics { get; set; }
        public double overall_sentiment_score { get; set; }
        public string overall_sentiment_label { get; set; }
        public List<TickerSentiment> ticker_sentiment { get; set; }
    }

    public class TickerSentiment
    {
        public string ticker { get; set; }
        public string relevance_score { get; set; }
        public string ticker_sentiment_score { get; set; }
        public string ticker_sentiment_label { get; set; }
    }

    public class Topic
    {
        public string topic { get; set; }
        public string relevance_score { get; set; }
    }
}
