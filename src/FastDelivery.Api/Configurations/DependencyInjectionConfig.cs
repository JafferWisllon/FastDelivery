using FastDelivery.Business;
using FastDelivery.Infra.Data;
using FastDelivery.Infra.Data.Repository;

namespace FastDelivery.Api
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder ResolveDependencies(this WebApplicationBuilder builder)
        {
            // Repositories
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IRecipientRepository, RecipientRepository>();
            builder.Services.AddScoped<IDeliverymanRepository, DeliverymanRepository>();

            // Services
            builder.Services.AddScoped<INotifier, Notifier>();
            builder.Services.AddScoped<IDeliverymanService, DeliverymanService>();
            builder.Services.AddScoped<IRecipientService, RecipientService>();
            return builder;
        }
    }
}
