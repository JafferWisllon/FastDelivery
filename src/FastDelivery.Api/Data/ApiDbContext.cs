using FastDelivery.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FastDelivery.Api.Data
{
    public sealed class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Recipient> Recipients { get; set; }
    }
}
