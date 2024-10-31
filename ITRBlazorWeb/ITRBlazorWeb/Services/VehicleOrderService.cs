using Evolve.ITR.Infrastructure.DataAccess.Contexts;
using Evolve.ITR.ServiceContract.Abstractions;
using Evolve.ITR.ServiceContract.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ITRBlazorWeb.Services
{
    public class VehicleOrderService(IDbContextFactory<TitleQuestDbContext> _db) : IVehicleOrderService
    {
        private readonly IDbContextFactory<TitleQuestDbContext> _dbFactory = _db;
        public async Task<VehicleOrderDTO> GetById(int spinAssetId)
        {
            using (var titleQuest = await _dbFactory.CreateDbContextAsync())
            {
                var vehicleOrderDb = await titleQuest.VehicleOrders
                                            .Where(v => v.SpinAssetId == spinAssetId)
                                            .Include(vo => vo.Requests)
                                            .Include(vo => vo.Client)
                                            .AsSplitQuery()
                                            .FirstOrDefaultAsync();
                return vehicleOrderDb?.ToDTO();
            }
        }
    }
}
