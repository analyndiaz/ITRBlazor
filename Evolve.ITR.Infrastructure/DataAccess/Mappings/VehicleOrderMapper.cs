using Evolve.ITR.TitleQuest.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evolve.ITR.Infrastructure.DataAccess.Mappings
{
    public class VehicleOrderMapper : IEntityTypeConfiguration<VehicleOrder>
    {
        public void Configure(EntityTypeBuilder<VehicleOrder> builder)
        {
            builder.HasKey(vo => vo.SpinAssetId);
            builder.HasOne(vo => vo.Client).WithMany(vo => vo.VehicleOrders).HasForeignKey(vo => vo.ClientNum);
            builder.HasMany(vo => vo.Requests).WithOne(r => r.VehicleOrder).HasForeignKey(r => r.VehicleOrderId);
        }
    }
}
