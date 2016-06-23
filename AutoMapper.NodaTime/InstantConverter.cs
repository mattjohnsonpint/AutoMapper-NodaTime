using System;
using NodaTime;

namespace AutoMapper.NodaTime
{
    public class InstantConverter :
        ITypeConverter<Instant, DateTime>,
        ITypeConverter<Instant, DateTime?>,
        ITypeConverter<Instant?, DateTime?>,
        ITypeConverter<Instant, DateTimeOffset>,
        ITypeConverter<Instant?, DateTimeOffset?>,
        ITypeConverter<DateTime, Instant>,
        ITypeConverter<DateTime, Instant?>,
        ITypeConverter<DateTime?, Instant?>,
        ITypeConverter<DateTimeOffset, Instant>,
        ITypeConverter<DateTimeOffset?, Instant?>
    {
        public void Configure(IConfiguration configuration)
        {
            configuration.CreateMap<Instant, DateTime>().ConvertUsing(this);
            configuration.CreateMap<Instant, DateTime?>().ConvertUsing(this);
            configuration.CreateMap<Instant?, DateTime?>().ConvertUsing(this);
            configuration.CreateMap<Instant, DateTimeOffset>().ConvertUsing(this);
            configuration.CreateMap<Instant?, DateTimeOffset?>().ConvertUsing(this);
            configuration.CreateMap<DateTime, Instant>().ConvertUsing(this);
            configuration.CreateMap<DateTime, Instant?>().ConvertUsing(this);
            configuration.CreateMap<DateTime?, Instant?>().ConvertUsing(this);
            configuration.CreateMap<DateTimeOffset, Instant>().ConvertUsing(this);
            configuration.CreateMap<DateTimeOffset?, Instant?>().ConvertUsing(this);
        }

        DateTime ITypeConverter<Instant, DateTime>.Convert(ResolutionContext context)
        {
            var instant = (Instant)context.SourceValue;
            return instant.ToDateTimeUtc();
        }

        DateTime? ITypeConverter<Instant, DateTime?>.Convert(ResolutionContext context)
        {
            var instant = (Instant)context.SourceValue;
            return instant.ToDateTimeUtc();
        }

        DateTime? ITypeConverter<Instant?, DateTime?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var instant = ((Instant?)context.SourceValue).Value;
            return instant.ToDateTimeUtc();
        }

        DateTimeOffset ITypeConverter<Instant, DateTimeOffset>.Convert(ResolutionContext context)
        {
            var instant = (Instant)context.SourceValue;
            return instant.ToDateTimeOffset();
        }

        DateTimeOffset? ITypeConverter<Instant?, DateTimeOffset?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var instant = ((Instant?)context.SourceValue).Value;
            return instant.ToDateTimeOffset();
        }

        Instant ITypeConverter<DateTime, Instant>.Convert(ResolutionContext context)
        {
            var dateTime = (DateTime)context.SourceValue;
            var utcDateTime = dateTime.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)
                : dateTime.ToUniversalTime();

            return Instant.FromDateTimeUtc(utcDateTime);
        }

        Instant? ITypeConverter<DateTime, Instant?>.Convert(ResolutionContext context)
        {
            var dateTime = (DateTime)context.SourceValue;
            var utcDateTime = dateTime.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)
                : dateTime.ToUniversalTime();

            return Instant.FromDateTimeUtc(utcDateTime);
        }

        Instant? ITypeConverter<DateTime?, Instant?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var dateTime = ((DateTime?)context.SourceValue).Value;
            var utcDateTime = dateTime.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)
                : dateTime.ToUniversalTime();

            return Instant.FromDateTimeUtc(utcDateTime);
        }

        Instant ITypeConverter<DateTimeOffset, Instant>.Convert(ResolutionContext context)
        {
            var dto = (DateTimeOffset)context.SourceValue;
            return Instant.FromDateTimeOffset(dto);
        }

        Instant? ITypeConverter<DateTimeOffset?, Instant?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var dto = ((DateTimeOffset?)context.SourceValue).Value;
            return Instant.FromDateTimeOffset(dto);
        }
    }
}
