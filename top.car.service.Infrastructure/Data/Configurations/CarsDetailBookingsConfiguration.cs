
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using top.car.service.Domain.Entities;

namespace top.car.service.Data.Configurations
{
    public class CarsDetailBookingsConfiguration : IEntityTypeConfiguration<CarsDetailBooking>
    {
        public void Configure(EntityTypeBuilder<CarsDetailBooking> builder)
        {
            // ── Relationships ────────────────────────────────────
            builder.HasMany(c => c.CarsDetailTravelers)
            .WithOne(s => s.CarsDetailBooking)
            .HasForeignKey(c => c.BookingId)
            .HasPrincipalKey(b => b.ItemNo); 
        }


    }
}
