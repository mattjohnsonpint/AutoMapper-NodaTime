using System;
using NodaTime;

namespace AutoMapper.NodaTime
{
    public class LocalDateConverter :
        ITypeConverter<LocalDate, DateTime>,
        ITypeConverter<LocalDate?, DateTime?>,
        ITypeConverter<DateTime, LocalDate>,
        ITypeConverter<DateTime?, LocalDate?>
    {
        public void Configure(IConfiguration configuration)
        {
            configuration.CreateMap<LocalDate, DateTime>().ConvertUsing(this);
            configuration.CreateMap<LocalDate?, DateTime?>().ConvertUsing(this);
            configuration.CreateMap<DateTime, LocalDate>().ConvertUsing(this);
            configuration.CreateMap<DateTime?, LocalDate?>().ConvertUsing(this);
        }

        DateTime ITypeConverter<LocalDate, DateTime>.Convert(ResolutionContext context)
        {
            var ld = (LocalDate)context.SourceValue;
            return ld.AtMidnight().ToDateTimeUnspecified();
        }

        DateTime? ITypeConverter<LocalDate?, DateTime?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var ld = ((LocalDate?)context.SourceValue).Value;
            return ld.AtMidnight().ToDateTimeUnspecified();
        }

        LocalDate ITypeConverter<DateTime, LocalDate>.Convert(ResolutionContext context)
        {
            var dt = (DateTime)context.SourceValue;
            return LocalDateTime.FromDateTime(dt).Date;
        }

        LocalDate? ITypeConverter<DateTime?, LocalDate?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var dt = ((DateTime?)context.SourceValue).Value;
            return LocalDateTime.FromDateTime(dt).Date;
        }
    }
}
