using Evolve.ITR.ServiceContract.Models;

namespace Evolve.ITR.ServiceContract.DTOs
{
    public interface IPreRequisiteService
    {
        Task<List<PreRequisiteDTO>> GetAll();
    }
}
