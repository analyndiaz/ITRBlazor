using Evolve.ITR.ServiceContract.DTOs;

namespace Evolve.ITR.ServiceContract.Abstractions
{
    public interface IVehicleOrderService
    {
        Task<VehicleOrderDTO> GetById(int spinAssetId);
    }
}
