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
        public TimeSpan Convert(Offset source, TimeSpan destination, ResolutionContext context)
        {
            return source.ToTimeSpan();
        }

        public TimeSpan? Convert(Offset? source, TimeSpan? destination, ResolutionContext context)
        {
            return source?.ToTimeSpan();
        }

        public Offset Convert(TimeSpan source, Offset destination, ResolutionContext context)
        {
            return Offset.FromTicks(source.Ticks);
        }

        public Offset? Convert(TimeSpan? source, Offset? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return Offset.FromTicks(source.Value.Ticks);
        }
    }
}
