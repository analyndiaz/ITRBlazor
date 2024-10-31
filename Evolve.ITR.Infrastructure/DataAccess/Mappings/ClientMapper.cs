using Evolve.ITR.TitleQuest.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evolve.ITR.Infrastructure.DataAccess.Mappings
{
    public class ClientMapper : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.VehicleOrders).WithOne(x => x.Client).HasForeignKey(x => x.ClientNum);
        }
    }
}
