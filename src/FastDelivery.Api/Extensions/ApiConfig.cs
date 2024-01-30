namespace FastDelivery.Api.Extensions
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            return builder;
        }
    }
}
