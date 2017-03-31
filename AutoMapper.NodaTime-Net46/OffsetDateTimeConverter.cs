using System;
using NodaTime;

namespace AutoMapper.NodaTime
{
    public class OffsetDateTimeConverter :
        ITypeConverter<OffsetDateTime, DateTimeOffset>,
        ITypeConverter<OffsetDateTime?, DateTimeOffset?>,
        ITypeConverter<DateTimeOffset, OffsetDateTime>,
        ITypeConverter<DateTimeOffset?, OffsetDateTime?>
    {
        public DateTimeOffset Convert(OffsetDateTime source, DateTimeOffset destination, ResolutionContext context)
        {
            return source.ToDateTimeOffset();
        }

        public DateTimeOffset? Convert(OffsetDateTime? source, DateTimeOffset? destination, ResolutionContext context)
        {
            return source?.ToDateTimeOffset();
        }

        public OffsetDateTime Convert(DateTimeOffset source, OffsetDateTime destination, ResolutionContext context)
        {
            return OffsetDateTime.FromDateTimeOffset(source);
        }

        public OffsetDateTime? Convert(DateTimeOffset? source, OffsetDateTime? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return OffsetDateTime.FromDateTimeOffset(source.Value);
        }
    }
}
