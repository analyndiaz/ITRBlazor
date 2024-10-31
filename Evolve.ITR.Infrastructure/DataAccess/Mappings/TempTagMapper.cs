using Evolve.ITR.TitleQuest.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evolve.ITR.Infrastructure.DataAccess.Mappings
{
    public class TempTagMapper : IEntityTypeConfiguration<TempTag>
    {
        public void Configure(EntityTypeBuilder<TempTag> builder)
        {
            builder.HasKey(vo => vo.Id);
            //builder.HasOne(t => t.VehicleOrder)
            //    .WithMany(r => r.TempTags)
            //    .HasForeignKey(t => t.VehicleOrderId);
        }
    }
}
