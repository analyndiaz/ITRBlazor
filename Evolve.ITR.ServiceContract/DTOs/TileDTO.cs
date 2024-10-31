using Evolve.ITR.ServiceContract.Enums;

namespace Evolve.ITR.ServiceContract.DTOs
{
    public class TileDTO
    {
        public string Title { get; set; } = string.Empty;
        public int Count { get; set; }
        public TileStatus Status { get; set; }
        public string Id { get; set; }
    }
}
