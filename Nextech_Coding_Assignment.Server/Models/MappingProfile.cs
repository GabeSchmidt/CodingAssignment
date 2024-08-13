using AutoMapper;
using Nextech_Coding_Assignment.Server.Models.AlphaVantage;

namespace Nextech_Coding_Assignment.Server.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BestMatchJson, BestMatch>();
            //CreateMap<IntraDayMetaDataJson, IntraDayMetaData>();
            CreateMap<TimeIntervalJson, TimeInterval>();
            CreateMap<DailyMetaDataJson, DailyMetaData>();
            //CreateMap<WeeklyOrMonthlyMetaDataJson, MetaData>();
            //CreateMap<WeeklyOrMonthlyMetaDataJson, MetaData>();
        }
    }
}
