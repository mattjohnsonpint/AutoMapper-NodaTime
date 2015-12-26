using System;
using NodaTime;
using Xunit;

namespace AutoMapper.NodaTime.UnitTests
{
    public class DurationTests
    {
        public DurationTests()
        {
            Mapper.Reset();
            Mapper.Initialize(x =>
            {
                new DurationConverter().Configure(x);

                x.CreateMap<Foo1, Foo3>().ReverseMap();
                x.CreateMap<Foo2, Foo4>().ReverseMap();
                x.CreateMap<Foo1, Foo5>().ReverseMap();
                x.CreateMap<Foo2, Foo6>().ReverseMap();
                x.CreateMap<Foo1, Foo7>().ReverseMap();
                x.CreateMap<Foo2, Foo8>().ReverseMap();
            });
        }

        [Fact]
        public void ValidateDurationMappings()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void CanConvertDurationToMinutes()
        {
            var foo = new Foo1 { Bar = Duration.FromMinutes(300) };

            var o = Mapper.Map<Foo7>(foo);

            Assert.Equal(300, o.Bar);
        }

        [Fact]
        public void CanConvertMinutesToDuration()
        {
            var foo = new Foo7 { Bar = 300 };

            var o = Mapper.Map<Foo1>(foo);

            Assert.Equal(Duration.FromMinutes(300), o.Bar);
        }

        public class Foo1
        {
            public Duration Bar { get; set; }
        }

        public class Foo2
        {
            public Duration? Bar { get; set; }
        }

        public class Foo3
        {
            public TimeSpan Bar { get; set; }
        }

        public class Foo4
        {
            public TimeSpan? Bar { get; set; }
        }

        public class Foo5
        {
            public long Bar { get; set; }
        }

        public class Foo6
        {
            public long? Bar { get; set; }
        }

        public class Foo7
        {
            [Duration(DurationUnits.Minutes)]
            public int Bar { get; set; }
        }

        public class Foo8
        {
            [Duration(DurationUnits.Minutes)]
            public int? Bar { get; set; }
        }
    }
}
