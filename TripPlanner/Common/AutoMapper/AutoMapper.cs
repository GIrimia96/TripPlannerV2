using AutoMapper;

namespace Common.AutoMapper
{
    public static class AutoMapper
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new LocationMapper());
            });

            return config;
        }
    }
}

