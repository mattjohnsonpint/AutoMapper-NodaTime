using NodaTime;
using NodaTime.Text;

namespace AutoMapper.NodaTime
{
    public class PeriodConverter :
        ITypeConverter<Period, string>,
        ITypeConverter<string, Period>
    {
        public string Convert(Period source, string destination, ResolutionContext context)
        {
            return source?.ToString();
        }

        public Period Convert(string source, Period destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return PeriodPattern.RoundtripPattern.Parse(source).Value;
        }
    }
}
