namespace Evolve.ITR.ServiceContract.DTOs
{
    public interface IDashboardService
    {
        Task<DashboardDTO> GetDashboardSections(string type);
        Task<int?> GetTileCount(string type);
        Task<List<VehicleOrderDTO>> GetTableViewList(string type);
    }
}
