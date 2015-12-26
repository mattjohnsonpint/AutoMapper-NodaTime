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
        public void Configure(IConfiguration configuration)
        {
            configuration.CreateMap<OffsetDateTime, DateTimeOffset>().ConvertUsing(this);
            configuration.CreateMap<OffsetDateTime?, DateTimeOffset?>().ConvertUsing(this);
            configuration.CreateMap<DateTimeOffset, OffsetDateTime>().ConvertUsing(this);
            configuration.CreateMap<DateTimeOffset?, OffsetDateTime?>().ConvertUsing(this);
        }

        DateTimeOffset ITypeConverter<OffsetDateTime, DateTimeOffset>.Convert(ResolutionContext context)
        {
            var odt = (OffsetDateTime)context.SourceValue;
            return odt.ToDateTimeOffset();
        }

        DateTimeOffset? ITypeConverter<OffsetDateTime?, DateTimeOffset?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var odt = ((OffsetDateTime?)context.SourceValue).Value;
            return odt.ToDateTimeOffset();
        }

        OffsetDateTime ITypeConverter<DateTimeOffset, OffsetDateTime>.Convert(ResolutionContext context)
        {
            var dto = (DateTimeOffset)context.SourceValue;
            return OffsetDateTime.FromDateTimeOffset(dto);
        }

        OffsetDateTime? ITypeConverter<DateTimeOffset?, OffsetDateTime?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var dto = ((DateTimeOffset?)context.SourceValue).Value;
            return OffsetDateTime.FromDateTimeOffset(dto);
        }
    }
}
