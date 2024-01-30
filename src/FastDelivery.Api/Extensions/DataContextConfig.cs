using FastDelivery.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace FastDelivery.Api.Extensions
{
    public static class DataContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return builder;
        }
    }
}
