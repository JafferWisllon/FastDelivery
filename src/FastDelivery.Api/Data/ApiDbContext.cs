using FastDelivery.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastDelivery.Api.Data
{
    public sealed class ApiDbContext : IdentityDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Deliveryman> Deliverymen { get; set; }
    }
}
