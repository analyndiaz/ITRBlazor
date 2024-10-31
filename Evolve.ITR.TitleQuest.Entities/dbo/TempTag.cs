using System.ComponentModel.DataAnnotations.Schema;

namespace Evolve.ITR.TitleQuest.Entities.dbo
{
    [Table("TempTag")]
    public class TempTag
    {
        public int Id { get; set; }
        public int VehicleOrderId { get; set; }
        public virtual VehicleOrder VehicleOrder { get; set; }
        public string TagState { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? AuditInsertDate { get; set; }
    }
}
