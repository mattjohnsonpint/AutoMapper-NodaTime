namespace AutoMapper.NodaTime
{
    public static class Configuration
    {
        public static void ConfigureForNodaTime(this IConfiguration configuration)
        {
            new DurationConverter().Configure(configuration);
            new InstantConverter().Configure(configuration);
            new LocalDateConverter().Configure(configuration);
            new LocalDateTimeConverter().Configure(configuration);
            new LocalTimeConverter().Configure(configuration);
            new OffsetConverter().Configure(configuration);
            new OffsetDateTimeConverter().Configure(configuration);
            new PeriodConverter().Configure(configuration);
        }
    }
}
