namespace FastDelivery.Api
{
    public static class AutoMapperConfig
    {
        public static WebApplicationBuilder AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return builder;
        }
    }
}
