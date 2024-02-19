using FastDelivery.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastDelivery.Infra.Data.Mappings
{
    public class DeliverymanMapping : IEntityTypeConfiguration<Deliveryman>
    {
        public void Configure(EntityTypeBuilder<Deliveryman> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.AvatarId)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Deliverymen");
        }
    }
}
