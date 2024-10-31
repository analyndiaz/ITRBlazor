using Evolve.ITR.Infrastructure.DataAccess.Contexts;
using Evolve.ITR.ServiceContract.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ITRBlazorWeb.Services
{
    public class PreRequisiteService(IDbContextFactory<TitleQuestDbContext> _db) : IPreRequisiteService
    {
        private readonly IDbContextFactory<TitleQuestDbContext> DbFactory = _db;

        public async Task<List<PreRequisiteDTO>> GetAll()
        {
            using var titleQuest = await DbFactory.CreateDbContextAsync();
            var result = await titleQuest.PreRequisites.DefaultIfEmpty().ToListAsync();
            return result.Select(x => x.ToDTO()).ToList();
        }
    }
}
