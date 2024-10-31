using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evolve.ITR.TitleQuest.Entities.dbo
{
    [Table("Client")]
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LegalName { get; set; }
        public virtual List<VehicleOrder> VehicleOrders { get; set; }
    }
}
