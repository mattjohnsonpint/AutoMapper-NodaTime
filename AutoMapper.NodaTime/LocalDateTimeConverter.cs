using System;
using NodaTime;

namespace AutoMapper.NodaTime
{
    public class LocalDateTimeConverter :
        ITypeConverter<LocalDateTime, DateTime>,
        ITypeConverter<LocalDateTime?, DateTime?>,
        ITypeConverter<DateTime, LocalDateTime>,
        ITypeConverter<DateTime?, LocalDateTime?>
    {
        public void Configure(IConfiguration configuration)
        {
            configuration.CreateMap<LocalDateTime, DateTime>().ConvertUsing(this);
            configuration.CreateMap<LocalDateTime?, DateTime?>().ConvertUsing(this);
            configuration.CreateMap<DateTime, LocalDateTime>().ConvertUsing(this);
            configuration.CreateMap<DateTime?, LocalDateTime?>().ConvertUsing(this);
        }

        DateTime ITypeConverter<LocalDateTime, DateTime>.Convert(ResolutionContext context)
        {
            var ldt = (LocalDateTime)context.SourceValue;
            return ldt.ToDateTimeUnspecified();
        }

        DateTime? ITypeConverter<LocalDateTime?, DateTime?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var ldt = ((LocalDateTime?)context.SourceValue).Value;
            return ldt.ToDateTimeUnspecified();
        }

        LocalDateTime ITypeConverter<DateTime, LocalDateTime>.Convert(ResolutionContext context)
        {
            var dt = (DateTime)context.SourceValue;
            return LocalDateTime.FromDateTime(dt);
        }

        LocalDateTime? ITypeConverter<DateTime?, LocalDateTime?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var dt = ((DateTime?)context.SourceValue).Value;
            return LocalDateTime.FromDateTime(dt);
        }
    }
}
