namespace Evolve.ITR.ServiceContract.Models
{
    public class PagedList<T>
    {
        public List<T> Result { get; set; }
        public int TotalCount { get; set; }
        public int ResultCount { get; set; }
    }
}
