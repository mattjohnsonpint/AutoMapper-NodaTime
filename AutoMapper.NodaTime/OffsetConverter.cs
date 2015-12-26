using System;
using NodaTime;

namespace AutoMapper.NodaTime
{
    public class OffsetConverter :
        ITypeConverter<Offset, TimeSpan>,
        ITypeConverter<Offset?, TimeSpan?>,
        ITypeConverter<TimeSpan, Offset>,
        ITypeConverter<TimeSpan?, Offset?>
    {
        public void Configure(IConfiguration configuration)
        {
            configuration.CreateMap<Offset, TimeSpan>().ConvertUsing(this);
            configuration.CreateMap<Offset?, TimeSpan?>().ConvertUsing(this);
            configuration.CreateMap<TimeSpan, Offset>().ConvertUsing(this);
            configuration.CreateMap<TimeSpan?, Offset?>().ConvertUsing(this);
        }

        TimeSpan ITypeConverter<Offset, TimeSpan>.Convert(ResolutionContext context)
        {
            var o = (Offset)context.SourceValue;
            return o.ToTimeSpan();
        }

        TimeSpan? ITypeConverter<Offset?, TimeSpan?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var o = ((Offset?)context.SourceValue).Value;
            return o.ToTimeSpan();
        }

        Offset ITypeConverter<TimeSpan, Offset>.Convert(ResolutionContext context)
        {
            var ts = (TimeSpan)context.SourceValue;
            return Offset.FromTicks(ts.Ticks);
        }

        Offset? ITypeConverter<TimeSpan?, Offset?>.Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
                return null;

            var ts = ((TimeSpan?)context.SourceValue).Value;
            return Offset.FromTicks(ts.Ticks);
        }
    }
}
