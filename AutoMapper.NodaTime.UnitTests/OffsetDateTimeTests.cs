using System;
using NodaTime;
using Xunit;

namespace AutoMapper.NodaTime.UnitTests
{
    public class OffsetDateTimeTests
    {
        [Fact]
        public void ValidateOffsetDateTimeMappings()
        {
            Mapper.Reset();
            Mapper.Initialize(x =>
            {
                new OffsetDateTimeConverter().Configure(x);

                x.CreateMap<Foo1, Foo3>().ReverseMap();
                x.CreateMap<Foo2, Foo4>().ReverseMap();
                x.CreateMap<Foo1, Foo5>().ReverseMap();
                x.CreateMap<Foo2, Foo6>().ReverseMap();
            });

            Mapper.AssertConfigurationIsValid();
        }

        public class Foo1
        {
            public Instant Bar { get; set; }
        }

        public class Foo2
        {
            public Instant? Bar { get; set; }
        }

        public class Foo3
        {
            public DateTime Bar { get; set; }
        }

        public class Foo4
        {
            public DateTime? Bar { get; set; }
        }

        public class Foo5
        {
            public DateTimeOffset Bar { get; set; }
        }

        public class Foo6
        {
            public DateTimeOffset? Bar { get; set; }
        }
    }
}
