using System;
using NodaTime;
using Xunit;

namespace AutoMapper.NodaTime.UnitTests
{
    public class DurationTests
    {
        private readonly IMapper _mapper;

        public DurationTests()
        { 
            var config = new MapperConfiguration(x =>
                {
                    x.AddProfile<NodaTimeProfile>();

                    x.CreateMap<Foo1, Foo3>().ReverseMap();
                    x.CreateMap<Foo2, Foo4>().ReverseMap();
                    x.CreateMap<Foo1, Foo5>().ReverseMap();
                    x.CreateMap<Foo2, Foo6>().ReverseMap();
                    x.CreateMap<Foo1, Foo7>().ReverseMap();
                    x.CreateMap<Foo2, Foo8>().ReverseMap();
                }
            );

            config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void CanConvertDurationToMinutes()
        {
            var foo = new Foo1 { Bar = Duration.FromMinutes(300) };

            var o = _mapper.Map<Foo7>(foo);

            Assert.Equal(18000, o.Bar);
        }

        [Fact]
        public void CanConvertMinutesToDuration()
        {
            var foo = new Foo7 { Bar = 300 };

            var o = _mapper.Map<Foo1>(foo);

            Assert.Equal(Duration.FromMinutes(5), o.Bar);
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
            public int Bar { get; set; }
        }

        public class Foo8
        {
            public int? Bar { get; set; }
        }
    }
}
