namespace Evolve.ITR.ServiceContract.DTOs
{
    public class PreRequisiteDTO
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string State { get; set; }
        public bool OriginalRequired { get; set; }
        public string Comment { get; set; }
        public string Provider { get; set; }
    }
}
