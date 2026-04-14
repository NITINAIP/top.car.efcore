
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using top.car.service.Domain.Entities;

namespace top.car.service.Data.Configurations
{
    public class CarsDetailReqConfiguration : IEntityTypeConfiguration<CarsDetailReq>
    {
        public void Configure(EntityTypeBuilder<CarsDetailReq> builder)
        {
            // ── Relationships ────────────────────────────────────
            builder.HasMany(c => c.CarsDetailBookings)
            .WithOne(c => c.CarsDetailReq)
            .HasForeignKey(c => c.CarReqDetailId);
        }


    }
}
