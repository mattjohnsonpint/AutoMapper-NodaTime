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
        public DateTime Convert(LocalDateTime source, DateTime destination, ResolutionContext context)
        {
            return source.ToDateTimeUnspecified();
        }

        public DateTime? Convert(LocalDateTime? source, DateTime? destination, ResolutionContext context)
        {
            return source?.ToDateTimeUnspecified();
        }

        public LocalDateTime Convert(DateTime source, LocalDateTime destination, ResolutionContext context)
        {
            return LocalDateTime.FromDateTime(source);
        }

        public LocalDateTime? Convert(DateTime? source, LocalDateTime? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return LocalDateTime.FromDateTime(source.Value);
        }
    }
}
