using Evolve.ITR.TitleQuest.Entities.vianac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evolve.ITR.Infrastructure.DataAccess.Mappings
{
    public class PreRequisiteMapper : IEntityTypeConfiguration<PreRequisite>
    {
        public void Configure(EntityTypeBuilder<PreRequisite> builder)
        {
            builder.HasKey(p => p.ttl_preqeq_id);
            builder.HasMany(p => p.Dimensions).WithOne(p => p.PreRequisite).HasForeignKey(p => p.ttl_preqeq_id);
            builder.HasOne(p => p.Provider).WithMany(p => p.PreRequisites).HasForeignKey(p => p.ttl_prereq_provider_cd);
        }
    }

    public class PrerequisiteDimensionMapper : IEntityTypeConfiguration<PreRequisiteDimension>
    {
        public void Configure(EntityTypeBuilder<PreRequisiteDimension> builder)
        {
            builder.HasKey(p => p.xref_row_id);
        }
    }

    public class PrerequisiteProviderMapper : IEntityTypeConfiguration<PreRequisiteProvider>
    {
        public void Configure(EntityTypeBuilder<PreRequisiteProvider> builder)
        {
            builder.HasKey(p => p.ttl_prereq_provider_cd);
        }
    }
}
