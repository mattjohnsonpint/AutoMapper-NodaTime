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
        public void Configure(IConfiguration configuration)
        {
            configuration.CreateMap<LocalTime, TimeSpan>().ConvertUsing(this);
            configuration.CreateMap<LocalTime?, TimeSpan?>().ConvertUsing(this);
            configuration.CreateMap<TimeSpan, LocalTime>().ConvertUsing(this);
            configuration.CreateMap<TimeSpan?, LocalTime?>().ConvertUsing(this);
            configuration.CreateMap<LocalTime, DateTime>().ConvertUsing(this);
            configuration.CreateMap<LocalTime?, DateTime?>().ConvertUsing(this);
            configuration.CreateMap<DateTime, LocalTime>().ConvertUsing(this);
            configuration.CreateMap<DateTime?, LocalTime?>().ConvertUsing(this);
        }

        TimeSpan ITypeConverter<LocalTime, TimeSpan>.Convert(ResolutionContext context)
        {
            var lt = (LocalTime)context.SourceValue;
            return new TimeSpan(lt.TickOfDay);
        }

        TimeSpan? ITypeConverter<LocalTime?, TimeSpan?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var lt = ((LocalTime?)context.SourceValue).Value;
            return new TimeSpan(lt.TickOfDay);
        }

        LocalTime ITypeConverter<TimeSpan, LocalTime>.Convert(ResolutionContext context)
        {
            var ts = (TimeSpan)context.SourceValue;
            return LocalTime.FromTicksSinceMidnight(ts.Ticks);
        }

        LocalTime? ITypeConverter<TimeSpan?, LocalTime?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var ts = ((TimeSpan?)context.SourceValue).Value;
            return LocalTime.FromTicksSinceMidnight(ts.Ticks);
        }

        DateTime ITypeConverter<LocalTime, DateTime>.Convert(ResolutionContext context)
        {
            var lt = (LocalTime)context.SourceValue;
            return lt.On(new LocalDate(1, 1, 1)).ToDateTimeUnspecified();
        }

        DateTime? ITypeConverter<LocalTime?, DateTime?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var lt = ((LocalTime?)context.SourceValue).Value;
            return lt.On(new LocalDate(1, 1, 1)).ToDateTimeUnspecified();
        }

        LocalTime ITypeConverter<DateTime, LocalTime>.Convert(ResolutionContext context)
        {
            var dt = (DateTime)context.SourceValue;
            return LocalDateTime.FromDateTime(dt).TimeOfDay;
        }

        LocalTime? ITypeConverter<DateTime?, LocalTime?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var dt = ((DateTime?)context.SourceValue).Value;
            return LocalDateTime.FromDateTime(dt).TimeOfDay;
        }
    }
}
