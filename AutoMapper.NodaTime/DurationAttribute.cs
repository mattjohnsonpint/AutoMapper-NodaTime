using System;

namespace AutoMapper.NodaTime
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DurationAttribute : Attribute
    {
        public DurationAttribute(DurationUnits units)
        {
            Units = units;
        }

        public DurationUnits Units { get; }
    }

    public enum DurationUnits
    {
        Ticks,
        Milliseconds,
        Seconds,
        Minutes,
        Hours
    }
}
