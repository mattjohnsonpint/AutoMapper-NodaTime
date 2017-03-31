using System;
using NodaTime;

namespace AutoMapper.NodaTime
{
    public class InstantConverter :
        ITypeConverter<Instant, DateTime>,
        ITypeConverter<Instant?, DateTime?>,
        ITypeConverter<Instant, DateTimeOffset>,
        ITypeConverter<Instant?, DateTimeOffset?>,
        ITypeConverter<DateTime, Instant>,
        ITypeConverter<DateTime?, Instant?>,
        ITypeConverter<DateTimeOffset, Instant>,
        ITypeConverter<DateTimeOffset?, Instant?>
    {
        public DateTime Convert(Instant source, DateTime destination, ResolutionContext context)
        {
            return source.ToDateTimeUtc();
        }

        public DateTime? Convert(Instant? source, DateTime? destination, ResolutionContext context)
        {
            return source?.ToDateTimeUtc();
        }

        public DateTimeOffset Convert(Instant source, DateTimeOffset destination, ResolutionContext context)
        {
            return source.ToDateTimeOffset();
        }

        public DateTimeOffset? Convert(Instant? source, DateTimeOffset? destination, ResolutionContext context)
        {
            return source?.ToDateTimeOffset();
        }

        public Instant Convert(DateTime source, Instant destination, ResolutionContext context)
        {
            var utcDateTime = source.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(source, DateTimeKind.Utc)
                : source.ToUniversalTime();

            return Instant.FromDateTimeUtc(utcDateTime);
        }

        public Instant? Convert(DateTime? source, Instant? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            var dateTime = source.Value;
            var utcDateTime = dateTime.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)
                : dateTime.ToUniversalTime();

            return Instant.FromDateTimeUtc(utcDateTime);
        }

        public Instant Convert(DateTimeOffset source, Instant destination, ResolutionContext context)
        {
            return Instant.FromDateTimeOffset(source);
        }

        public Instant? Convert(DateTimeOffset? source, Instant? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return Instant.FromDateTimeOffset(source.Value);
        }
    }
}