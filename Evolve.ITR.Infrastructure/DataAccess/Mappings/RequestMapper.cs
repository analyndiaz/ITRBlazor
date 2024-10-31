using Evolve.ITR.TitleQuest.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evolve.ITR.Infrastructure.DataAccess.Mappings
{
    public class RequestMapper : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(vo => vo.Id);
            builder.HasOne(r => r.VehicleOrder).WithMany(o => o.Requests).HasForeignKey(r => r.VehicleOrderId);
        }
    }
}
