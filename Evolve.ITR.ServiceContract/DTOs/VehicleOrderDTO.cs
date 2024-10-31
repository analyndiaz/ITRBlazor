using Evolve.ITR.ServiceContract.Enums;

namespace Evolve.ITR.ServiceContract.DTOs
{
    public class VehicleOrderDTO
    {
        public int SpinAssetId { get; set; }
        public string ClientNum { get; set; }
        public string ClientName { get; set; }
        public string Dan { get; set; }
        public string UnitNum { get; set; }
        public string ClientBreakdown { get; set; }
        public string Vin { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleModelYear { get; set; }

        // ALL BELOW ARE NULLABLE IN THE DB. CRAPPY C# VERSION PREVENTS NULLABLE REF TYPES
        public string VehicleSeries { get; set; }
        public int? DeliveryType { get; set; }
        public string FactoryOrderNumber { get; set; }
        public DateTime? BuiltOn { get; set; }
        public DateTime? MsoMailedOn { get; set; }
        public DateTime? MsoReceivedOn { get; set; }
        public DateTime? DeliveredToDealerOn { get; set; }
        public DateTime? DeliveredToClientOn { get; set; }
        public DateTime? AddedOn { get; set; }
        public string HoldReason1 { get; set; }
        public string HoldReason2 { get; set; }
        public string HoldReason3 { get; set; }
        public string HoldReason4 { get; set; }
        public string HoldReason5 { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public string DriverAddressLine1 { get; set; }
        public string DriverAddressLine2 { get; set; }
        public string DriverCity { get; set; }
        public string DriverCounty { get; set; }
        public string DriverStateProv { get; set; }
        public string DriverPhone { get; set; }
        public string DriverEmail { get; set; }
        public string RequestStates { get; set; }
        public List<DateTime> RequestDates { get; set; }
        public VehicleStageOptions? CurrentStage
        {
            get
            {
                if (!BuiltOn.HasValue && !DeliveredToDealerOn.HasValue && !DeliveredToClientOn.HasValue)
                {
                    return VehicleStageOptions.Ordered;
                }
                else if (BuiltOn.HasValue && !DeliveredToDealerOn.HasValue && !DeliveredToClientOn.HasValue)
                {
                    return VehicleStageOptions.Built;
                }
                else if (DeliveredToDealerOn.HasValue && !DeliveredToClientOn.HasValue)
                {
                    return VehicleStageOptions.DealerDelivered;
                }
                else if (DeliveredToClientOn.HasValue)
                {
                    return VehicleStageOptions.ClientDelivered;
                }

                return null;
            }
        }
        public List<RequestDTO> Requests { get; set; }
        //public List<TempTagDTO> TempTags { get; set; }

        public VehicleOrderDTO()
        {
            Requests = new List<RequestDTO>();
        }
    }
}
