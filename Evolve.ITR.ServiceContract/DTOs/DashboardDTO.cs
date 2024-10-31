namespace Evolve.ITR.ServiceContract.DTOs
{
    public class DashboardDTO
    {
        public List<TileSectionDTO> TileSections { get; set; }
        public DashboardDTO()
        { 
            TileSections = new List<TileSectionDTO>();
        }
    }
}
