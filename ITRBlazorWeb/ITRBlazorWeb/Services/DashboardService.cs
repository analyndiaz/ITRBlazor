using Evolve.ITR.Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Evolve.ITR.Infrastructure.DataAccess.Extensions;
using Evolve.ITR.ServiceContract.Enums;
using Evolve.ITR.ServiceContract.DTOs;
using Evolve.ITR.TitleQuest.Entities.dbo;
using Microsoft.Extensions.Caching.Memory;

namespace ITRBlazorWeb.Services
{
    public class DashboardService(IDbContextFactory<TitleQuestDbContext> _db, 
                                  IMemoryCache cache) : IDashboardService
    {
        private readonly IDbContextFactory<TitleQuestDbContext> _dbFactory = _db;
        private readonly IMemoryCache _memoryCache = cache;

        #region Tiles
        public async Task<DashboardDTO> GetDashboardSections(string type)
        {
            var dashboardDto = new DashboardDTO();
            if (type == "core")
            {
                dashboardDto.TileSections.Add(new TileSectionDTO
                {
                    Title = "Outstanding Prerequisites",
                    Tiles = [
                                new TileDTO()
                                {
                                    Id = "VehiclesMissingElementPrereqs",
                                    Title = "Vehicles Missing Element Prerequisites",
                                    Status = TileStatus.Danger,
                                },
                            ]
                });
                dashboardDto.TileSections.Add(new TileSectionDTO
                {
                    Title = "Manufacturer Statement of Origin (MSO) Review",
                    Tiles = [
                                new TileDTO()
                                {
                                    Id = "MsoMailedInTransit",
                                    Title = "MSO Mailed, In Transit From Factory",
                                    Status = TileStatus.Alert,
                                },
                                new TileDTO()
                                {
                                    Id = "MsoReviewInProgress",
                                    Title = "MSO Review in Progress",
                                    Status = TileStatus.Alert,
                                },
                            ]
                });
            }
            else if (type == "client")
            {
                dashboardDto.TileSections.Add(new TileSectionDTO
                {
                    Title = "Outstanding Prerequisites",
                    Tiles = [
                                new TileDTO()
                                {
                                    Id = "VehiclesMissingClientPrereqs",
                                    Title = "Vehicles Missing Your Prerequisites",
                                    Status = TileStatus.Danger,
                                },
                                new TileDTO()
                                {
                                    Id = "VehiclesMissingDriverPrereqs",
                                    Title = "Vehicles Missing Driver Prerequisites",
                                    Status = TileStatus.Danger,
                                }
                            ]
                });
            }

            return dashboardDto;
        }
        #endregion

        public async Task<int?> GetTileCount(string type)
        {
            string cacheLookup = $"{type}Count";
            if (_memoryCache.TryGetValue(cacheLookup, out int? cachedValue))
            {
                return cachedValue;
            }

            using (var titleQuest = await _dbFactory.CreateDbContextAsync())
            {
                var selector = GetSelector(type);
                var query = titleQuest.VehicleOrders.Where(selector);
                var result = await query.CountAsync();

                _memoryCache.Set(cacheLookup, result, TimeSpan.FromMinutes(5));

                return result;
            }
        }

        public async Task<List<VehicleOrderDTO>> GetTableViewList(string type)
        {
            string cacheLookup = $"{type}";
            if (_memoryCache.TryGetValue(cacheLookup, out List<VehicleOrderDTO> cachedValue))
            {
                return cachedValue;
            }

            using (var titleQuest = await _dbFactory.CreateDbContextAsync())
            {
                var selector = GetSelector(type);
                var query = titleQuest.VehicleOrders.Where(selector).Include(vo => vo.Client).AsSplitQuery();
                var result = (await query.DefaultIfEmpty().ToListAsync())
                                    .Select(r => r.ToTableViewDTO()).ToList();

                _memoryCache.Set(cacheLookup, result, TimeSpan.FromMinutes(5));

                return result;
            }
        }

        private Expression<Func<VehicleOrder, bool>> GetSelector(string type)
        {
            Expression<Func<VehicleOrder, bool>> selector = DefaultSelector();

            if (type == "VehiclesMissingElementPrereqs")
            {
                return selector.And(vo => vo.Requests.Any(r => r.PreReqProviderCode.Contains(((int)PrereqProviderCode.Element).ToString())));
            }
            else if (type == "VehiclesMissingDriverPrereqs")
            {
                return selector.And(vo => vo.Requests.Any(r => r.PreReqProviderCode.Contains(((int)PrereqProviderCode.Driver).ToString())));
            }
            else if (type == "VehiclesMissingClientPrereqs")
            {
                return selector.And(vo => vo.Requests.Any(r => r.PreReqProviderCode.Contains(((int)PrereqProviderCode.Client).ToString())));
            }
            else if (type == "MsoMailedInTransit")
            {
                return selector.And(vo => !vo.MsoReceivedOn.HasValue &&
                                            (
                                                (
                                                    (!vo.DeliveryType.HasValue || vo.DeliveryType.Value == (int)VehicleOriginOptions.Factory)
                                                    && vo.BuiltOn.HasValue
                                                ) ||
                                                vo.DeliveryType.Value == (int)VehicleOriginOptions.Stock
                                            )
                                    );
            }
            else if (type == "MsoReviewInProgress")
            {
                return selector.And(vo => (!vo.DeliveryType.HasValue || vo.DeliveryType.Value == (int)VehicleOriginOptions.Factory) && vo.MsoReceivedOn.HasValue);
            }
            else if (type == "MsoReviewCurrentTempTags")
            {
                return selector.And(vo => vo.TempTags.Any(t => t.ExpirationDate.HasValue && t.ExpirationDate.Value >= DateTime.Now));
            }
            else if (type == "MsoReviewExpiredTempTags")
            {
                return selector.And(vo => vo.TempTags.Any(t => t.ExpirationDate.HasValue && t.ExpirationDate.Value < DateTime.Now));
            }
            else
            {
                return selector;
            }
        }

        private Expression<Func<VehicleOrder, bool>> DefaultSelector(Expression<Func<Request, bool>> requestSelector = null)
        {
            var exStatusCodes = new int[] { 12, 20, 33, 34, 38, 42, 55, 64, 70, 76, 81, 84, 92, 96, 97, 103, 107, 115, 121 };
            Expression<Func<Request, bool>> selector = r => r.StatusCode.HasValue && !exStatusCodes.Contains(r.StatusCode.Value);

            if (requestSelector != null)
            {
                selector = selector.And(requestSelector);
            }

            return vo => vo.Requests.AsQueryable().Any(selector);
        }
    }
}
