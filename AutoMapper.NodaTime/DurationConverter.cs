using System;
using System.Linq;
using System.Reflection;
using NodaTime;

namespace AutoMapper.NodaTime
{
    public class DurationConverter :
        ITypeConverter<Duration, TimeSpan>,
        ITypeConverter<Duration?, TimeSpan?>,
        ITypeConverter<TimeSpan, Duration>,
        ITypeConverter<TimeSpan?, Duration?>,
        ITypeConverter<Duration, long>,
        ITypeConverter<Duration?, long?>,
        ITypeConverter<long, Duration>,
        ITypeConverter<long?, Duration?>,
        ITypeConverter<Duration, int>,
        ITypeConverter<Duration?, int?>,
        ITypeConverter<int, Duration>,
        ITypeConverter<int?, Duration?>,
        ITypeConverter<Duration, double>,
        ITypeConverter<Duration?, double?>,
        ITypeConverter<double, Duration>,
        ITypeConverter<double?, Duration?>,
        ITypeConverter<Duration, decimal>,
        ITypeConverter<Duration?, decimal?>,
        ITypeConverter<decimal, Duration>,
        ITypeConverter<decimal?, Duration?>
    {
        public void Configure(IConfiguration configuration)
        {
            configuration.CreateMap<Duration, TimeSpan>().ConvertUsing(this);
            configuration.CreateMap<Duration?, TimeSpan?>().ConvertUsing(this);
            configuration.CreateMap<TimeSpan, Duration>().ConvertUsing(this);
            configuration.CreateMap<TimeSpan?, Duration?>().ConvertUsing(this);
            configuration.CreateMap<Duration, long>().ConvertUsing(this);
            configuration.CreateMap<Duration?, long?>().ConvertUsing(this);
            configuration.CreateMap<long, Duration>().ConvertUsing(this);
            configuration.CreateMap<long?, Duration?>().ConvertUsing(this);
            configuration.CreateMap<Duration, int>().ConvertUsing(this);
            configuration.CreateMap<Duration?, int?>().ConvertUsing(this);
            configuration.CreateMap<int, Duration>().ConvertUsing(this);
            configuration.CreateMap<int?, Duration?>().ConvertUsing(this);
            configuration.CreateMap<Duration, double>().ConvertUsing(this);
            configuration.CreateMap<Duration?, double?>().ConvertUsing(this);
            configuration.CreateMap<double, Duration>().ConvertUsing(this);
            configuration.CreateMap<double?, Duration?>().ConvertUsing(this);
            configuration.CreateMap<Duration, decimal>().ConvertUsing(this);
            configuration.CreateMap<Duration?, decimal?>().ConvertUsing(this);
            configuration.CreateMap<decimal, Duration>().ConvertUsing(this);
            configuration.CreateMap<decimal?, Duration?>().ConvertUsing(this);
        }

        TimeSpan ITypeConverter<Duration, TimeSpan>.Convert(ResolutionContext context)
        {
            var d = (Duration)context.SourceValue;
            return d.ToTimeSpan();
        }

        TimeSpan? ITypeConverter<Duration?, TimeSpan?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var d = ((Duration?)context.SourceValue).Value;
            return d.ToTimeSpan();
        }

        Duration ITypeConverter<TimeSpan, Duration>.Convert(ResolutionContext context)
        {
            var ts = (TimeSpan)context.SourceValue;
            return Duration.FromTimeSpan(ts);
        }

        Duration? ITypeConverter<TimeSpan?, Duration?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var ts = ((TimeSpan?)context.SourceValue).Value;
            return Duration.FromTimeSpan(ts);
        }

        long ITypeConverter<Duration, long>.Convert(ResolutionContext context)
        {
            var d = (Duration)context.SourceValue;
            return d.Ticks / GetTicksPerUnitFromDestination(context);
        }

        long? ITypeConverter<Duration?, long?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var d = ((Duration?)context.SourceValue).Value;
            return d.Ticks / GetTicksPerUnitFromDestination(context);
        }

        Duration ITypeConverter<long, Duration>.Convert(ResolutionContext context)
        {
            var value = (long)context.SourceValue;
            return Duration.FromTicks(value * GetTicksPerUnitFromSource(context));
        }

        Duration? ITypeConverter<long?, Duration?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var value = ((long?)context.SourceValue).Value;
            return Duration.FromTicks(value * GetTicksPerUnitFromSource(context));
        }

        int ITypeConverter<Duration, int>.Convert(ResolutionContext context)
        {
            var d = (Duration)context.SourceValue;
            return (int)(d.Ticks / GetTicksPerUnitFromDestination(context));
        }

        int? ITypeConverter<Duration?, int?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var d = ((Duration?)context.SourceValue).Value;
            return (int)(d.Ticks / GetTicksPerUnitFromDestination(context));
        }

        Duration ITypeConverter<int, Duration>.Convert(ResolutionContext context)
        {
            var value = (int)context.SourceValue;
            return Duration.FromTicks(value * GetTicksPerUnitFromSource(context));
        }

        Duration? ITypeConverter<int?, Duration?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var value = ((int?)context.SourceValue).Value;
            return Duration.FromTicks(value * GetTicksPerUnitFromSource(context));
        }

        double ITypeConverter<Duration, double>.Convert(ResolutionContext context)
        {
            var d = (Duration)context.SourceValue;
            return (double)d.Ticks / GetTicksPerUnitFromDestination(context);
        }

        double? ITypeConverter<Duration?, double?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var d = ((Duration?)context.SourceValue).Value;
            return (double)d.Ticks / GetTicksPerUnitFromDestination(context);
        }

        Duration ITypeConverter<double, Duration>.Convert(ResolutionContext context)
        {
            var value = (double)context.SourceValue;
            return Duration.FromTicks((long)(value * GetTicksPerUnitFromSource(context)));
        }

        Duration? ITypeConverter<double?, Duration?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var value = ((double?)context.SourceValue).Value;
            return Duration.FromTicks((long)(value * GetTicksPerUnitFromSource(context)));
        }

        decimal ITypeConverter<Duration, decimal>.Convert(ResolutionContext context)
        {
            var d = (Duration)context.SourceValue;
            return (decimal)d.Ticks / GetTicksPerUnitFromDestination(context);
        }

        decimal? ITypeConverter<Duration?, decimal?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var d = ((Duration?)context.SourceValue).Value;
            return (decimal)d.Ticks / GetTicksPerUnitFromDestination(context);
        }

        Duration ITypeConverter<decimal, Duration>.Convert(ResolutionContext context)
        {
            var value = (decimal)context.SourceValue;
            return Duration.FromTicks((long)(value * GetTicksPerUnitFromSource(context)));
        }

        Duration? ITypeConverter<decimal?, Duration?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var value = ((decimal?)context.SourceValue).Value;
            return Duration.FromTicks((long)(value * GetTicksPerUnitFromSource(context)));
        }

        private static long GetTicksPerUnitFromSource(ResolutionContext context)
        {
            return GetTicksPerUnit(context.PropertyMap.SourceMember);
        }

        private static long GetTicksPerUnitFromDestination(ResolutionContext context)
        {
            return GetTicksPerUnit(context.PropertyMap.DestinationProperty.MemberInfo);
        }

        private static long GetTicksPerUnit(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttributes(true).OfType<DurationAttribute>().FirstOrDefault();

            var units = attribute?.Units ?? DurationUnits.Seconds; // default to seconds

            switch (units)
            {
                case DurationUnits.Ticks:
                    return 1;
                case DurationUnits.Milliseconds:
                    return NodaConstants.TicksPerMillisecond;
                case DurationUnits.Seconds:
                    return NodaConstants.TicksPerSecond;
                case DurationUnits.Minutes:
                    return NodaConstants.TicksPerMinute;
                case DurationUnits.Hours:
                    return NodaConstants.TicksPerHour;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
