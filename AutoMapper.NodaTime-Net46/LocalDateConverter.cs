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
        public DateTime Convert(LocalDate source, DateTime destination, ResolutionContext context)
        {
            return source.AtMidnight().ToDateTimeUnspecified();
        }

        public DateTime? Convert(LocalDate? source, DateTime? destination, ResolutionContext context)
        {
            if (source == null)
                return null;

            return source.Value.AtMidnight().ToDateTimeUnspecified();
        }

        public LocalDate Convert(DateTime source, LocalDate destination, ResolutionContext context)
        {
            return LocalDateTime.FromDateTime(source).Date;
        }

        public LocalDate? Convert(DateTime? source, LocalDate? destination, ResolutionContext context)
        {
            if (source == null)
                return null;

            return LocalDateTime.FromDateTime(source.Value).Date;
        }
    }
}
