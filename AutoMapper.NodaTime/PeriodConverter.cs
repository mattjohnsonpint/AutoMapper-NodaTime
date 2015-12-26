using NodaTime;
using NodaTime.Text;

namespace AutoMapper.NodaTime
{
    public class PeriodConverter :
        ITypeConverter<Period, string>,
        ITypeConverter<string, Period>
    {
        public void Configure(IConfiguration configuration)
        {
            configuration.CreateMap<Period, string>().ConvertUsing(this);
            configuration.CreateMap<string, Period>().ConvertUsing(this);
        }

        string ITypeConverter<Period, string>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var p = (Period)context.SourceValue;
            return p.ToString();
        }

        Period ITypeConverter<string, Period>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var s = (string)context.SourceValue;
            return PeriodPattern.RoundtripPattern.Parse(s).Value;
        }
    }
}
