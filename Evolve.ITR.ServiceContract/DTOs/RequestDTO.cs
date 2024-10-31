using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolve.ITR.ServiceContract.DTOs
{
    public class RequestDTO
    {
        public int Id { get; set; }

        public int VehicleOrderId { get; set; }
        public int ProcessId { get; set; }
        public int? PackageIndicator { get; set; }

        [ForeignKey(nameof(CurrentTask))]
        public int CurrentTaskId { get; set; }
        public virtual Task CurrentTask { get; set; }

        public virtual List<Task> AllTasks { get; set; }

        public int? StatusCode { get; set; }
        public string RequestState { get; set; }
        public DateTime? RequestReceivedAt { get; set; }
        public DateTime? RequestDueAt { get; set; }
        public DateTime? RequestCompletedOn { get; set; }

        public bool? InDntQueue { get; set; }
        public string PreReqProviderCode { get; set; }
    }
}
