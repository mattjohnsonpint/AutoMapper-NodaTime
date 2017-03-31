using System;
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
        public TimeSpan Convert(Duration source, TimeSpan destination, ResolutionContext context)
        {
            return source.ToTimeSpan();
        }

        public TimeSpan? Convert(Duration? source, TimeSpan? destination, ResolutionContext context)
        {
            return source?.ToTimeSpan();
        }

        public Duration Convert(TimeSpan source, Duration destination, ResolutionContext context)
        {
            return Duration.FromTimeSpan(source);
        }

        public Duration? Convert(TimeSpan? source, Duration? destination, ResolutionContext context)
        {
            return source != null ? (Duration?)Duration.FromTimeSpan(source.Value) : null;
        }

        public long Convert(Duration source, long destination, ResolutionContext context)
        {
            return source.Ticks / NodaConstants.TicksPerSecond;
        }

        public long? Convert(Duration? source, long? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return source.Value.Ticks / NodaConstants.TicksPerSecond;
        }

        public Duration Convert(long source, Duration destination, ResolutionContext context)
        {
            return Duration.FromTicks(source * NodaConstants.TicksPerSecond);
        }

        public Duration? Convert(long? source, Duration? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return Duration.FromTicks(source.Value * NodaConstants.TicksPerSecond);
        }

        public int Convert(Duration source, int destination, ResolutionContext context)
        {
            return (int)(source.Ticks / NodaConstants.TicksPerSecond);
        }

        public int? Convert(Duration? source, int? destination, ResolutionContext context)
        {
            if (source == null)
                return null;

            return (int)(source.Value.Ticks / NodaConstants.TicksPerSecond);
        }

        public Duration Convert(int source, Duration destination, ResolutionContext context)
        {
            return Duration.FromTicks(source * NodaConstants.TicksPerSecond);
        }

        public Duration? Convert(int? source, Duration? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return Duration.FromTicks(source.Value * NodaConstants.TicksPerSecond);
        }

        public double Convert(Duration source, double destination, ResolutionContext context)
        {
            return (double)source.Ticks / NodaConstants.TicksPerSecond;
        }

        public double? Convert(Duration? source, double? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return (double)source.Value.Ticks / NodaConstants.TicksPerSecond;
        }

        public Duration Convert(double source, Duration destination, ResolutionContext context)
        {
            return Duration.FromTicks((long)(source * NodaConstants.TicksPerSecond));
        }

        public Duration? Convert(double? source, Duration? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return Duration.FromTicks((long)(source.Value * NodaConstants.TicksPerSecond));
        }

        public decimal Convert(Duration source, decimal destination, ResolutionContext context)
        {
            return (decimal)source.Ticks / NodaConstants.TicksPerSecond;
        }

        public decimal? Convert(Duration? source, decimal? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return (decimal)source.Value.Ticks / NodaConstants.TicksPerSecond;
        }

        public Duration Convert(decimal source, Duration destination, ResolutionContext context)
        {
            return Duration.FromTicks((long)(source * NodaConstants.TicksPerSecond));
        }

        public Duration? Convert(decimal? source, Duration? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return Duration.FromTicks((long)(source.Value * NodaConstants.TicksPerSecond));
        }
    }
}
