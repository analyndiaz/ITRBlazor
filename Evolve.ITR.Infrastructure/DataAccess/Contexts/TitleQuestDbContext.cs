using Evolve.ITR.Infrastructure.DataAccess.Mappings;
using Evolve.ITR.TitleQuest.Entities.dbo;
using Evolve.ITR.TitleQuest.Entities.vianac;
using Microsoft.EntityFrameworkCore;

namespace Evolve.ITR.Infrastructure.DataAccess.Contexts
{
    public class TitleQuestDbContext(DbContextOptions<TitleQuestDbContext> options) : DbContext(options)
    {
        public DbSet<VehicleOrder> VehicleOrders { get; set; }
        public DbSet<PreRequisite> PreRequisites { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RequestMapper());
            modelBuilder.ApplyConfiguration(new TempTagMapper());
            modelBuilder.ApplyConfiguration(new VehicleOrderMapper());
            modelBuilder.ApplyConfiguration(new PreRequisiteMapper());
            modelBuilder.ApplyConfiguration(new PrerequisiteDimensionMapper());
            modelBuilder.ApplyConfiguration(new PrerequisiteProviderMapper());
            modelBuilder.ApplyConfiguration(new ClientMapper());

            //Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => type.BaseType != null &&
            //                   type.BaseType.IsGenericType &&
            //                   (type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
            //    .ToList()
            //    .ForEach(type =>
            //    {
            //        dynamic instance = Activator.CreateInstance(type);
            //        modelBuilder.ApplyConfiguration(instance);
            //    });
        }
    }
}
