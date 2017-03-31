using System;
using NodaTime;
using Xunit;

namespace AutoMapper.NodaTime.UnitTests
{
    public class OffsetDateTimeTests
    {
        [Fact]
        public void ValidateMapping()
        {
            var config = new MapperConfiguration(x =>
                {
                    x.AddProfile<NodaTimeProfile>();

                    x.CreateMap<Foo1, Foo3>().ReverseMap();
                    x.CreateMap<Foo2, Foo4>().ReverseMap();
                    x.CreateMap<Foo3, Foo1>().ReverseMap();
                    x.CreateMap<Foo4, Foo2>().ReverseMap();
                }
            );

            config.AssertConfigurationIsValid();
        }

        public class Foo1
        {
            public OffsetDateTime Bar { get; set; }
        }

        public class Foo2
        {
            public OffsetDateTime? Bar { get; set; }
        }

        public class Foo3
        {
            public DateTimeOffset Bar { get; set; }
        }

        public class Foo4
        {
            public DateTimeOffset? Bar { get; set; }
        }
    }
}
