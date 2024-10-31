using Evolve.ITR.ServiceContract.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evolve.ITR.TitleQuest.Entities.dbo
{
    [Table("Request")]
    public class Request
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(VehicleOrder))]
        public int VehicleOrderId { get; set; }
        public int ProcessId { get; set; }
        public int? PackageIndicator { get; set; }

        //[ForeignKey(nameof(CurrentTask))]
        public int? CurrentTaskId { get; set; }
        public int? StatusCode { get; set; }
        public string RequestState { get; set; }
        public DateTime? RequestReceivedAt { get; set; }
        public DateTime? RequestDueAt { get; set; }
        public DateTime? RequestCompletedOn { get; set; }
        public bool? InDntQueue { get; set; }
        public string PreReqProviderCode { get; set; }
        public virtual VehicleOrder VehicleOrder { get; set; }

        public RequestDTO ToDTO()
        {
            return new RequestDTO()
            {
                Id = Id,
                VehicleOrderId = VehicleOrderId,
                //VehicleOrder = VehicleOrder?.ToDTO(),
                ProcessId = ProcessId,
                //CurrentTaskId = CurrentTaskId,
                StatusCode = StatusCode,
                RequestState = RequestState,
                RequestReceivedAt = RequestReceivedAt,
                RequestDueAt = RequestDueAt,
                RequestCompletedOn = RequestCompletedOn,
                InDntQueue = InDntQueue.GetValueOrDefault(),
            };
        }
    }
}
