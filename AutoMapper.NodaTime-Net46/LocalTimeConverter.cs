using System;
using NodaTime;

namespace AutoMapper.NodaTime
{
    public class LocalTimeConverter :
        ITypeConverter<LocalTime, TimeSpan>,
        ITypeConverter<LocalTime?, TimeSpan?>,
        ITypeConverter<TimeSpan, LocalTime>,
        ITypeConverter<TimeSpan?, LocalTime?>,
        ITypeConverter<LocalTime, DateTime>,
        ITypeConverter<LocalTime?, DateTime?>,
        ITypeConverter<DateTime, LocalTime>,
        ITypeConverter<DateTime?, LocalTime?>
    {
        public TimeSpan Convert(LocalTime source, TimeSpan destination, ResolutionContext context)
        {
            return new TimeSpan(source.TickOfDay);
        }

        public TimeSpan? Convert(LocalTime? source, TimeSpan? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return new TimeSpan(source.Value.TickOfDay);
        }

        public LocalTime Convert(TimeSpan source, LocalTime destination, ResolutionContext context)
        {
            return LocalTime.FromTicksSinceMidnight(source.Ticks);
        }

        public LocalTime? Convert(TimeSpan? source, LocalTime? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return LocalTime.FromTicksSinceMidnight(source.Value.Ticks);
        }

        public DateTime Convert(LocalTime source, DateTime destination, ResolutionContext context)
        {
            return source.On(new LocalDate(1, 1, 1)).ToDateTimeUnspecified();
        }

        public DateTime? Convert(LocalTime? source, DateTime? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return source.Value.On(new LocalDate(1, 1, 1)).ToDateTimeUnspecified();
        }

        public LocalTime Convert(DateTime source, LocalTime destination, ResolutionContext context)
        {
            return LocalDateTime.FromDateTime(source).TimeOfDay;
        }

        public LocalTime? Convert(DateTime? source, LocalTime? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return LocalDateTime.FromDateTime(source.Value).TimeOfDay;
        }
    }
}
