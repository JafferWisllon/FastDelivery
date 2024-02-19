using FastDelivery.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastDelivery.Infra.Data.Mappings
{
    public class RecipientMapping : IEntityTypeConfiguration<Recipient>
    {
        public void Configure(EntityTypeBuilder<Recipient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Street)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Complement)
                .HasColumnType("varchar(200)");

            builder.Property(x => x.City)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.State)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(x => x.ZipCode)
               .IsRequired()
               .HasColumnType("varchar(8)");

            builder.ToTable("Recipients");
        }
    }
}
