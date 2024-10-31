using Evolve.ITR.ServiceContract.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evolve.ITR.TitleQuest.Entities.dbo
{
    [Table("VehicleOrder")]
    public class VehicleOrder
    {
        [Key]
        public int SpinAssetId { get; set; }
        [ForeignKey(nameof(Client))]
        public string ClientNum { get; set; }
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
        public string RegistrationNumber { get; set; }
        public DateTime? RegistrationExpiredOn { get; set; }
        public string RegistrationState { get; set; }
        public DateTime? SupplierArrivalOn { get; set; }
        public DateTime? TitleIssuedOn { get; set; }
        public DateTime? TargetDeliveryOn { get; set; }
        public virtual List<Request> Requests { get; set; }
        public virtual List<TempTag> TempTags { get; set; }
        public virtual Client? Client { get; set; }

        public VehicleOrderDTO ToTableViewDTO()
        {
            return new VehicleOrderDTO()
            {
                SpinAssetId = SpinAssetId,
                ClientNum = ClientNum,
                ClientName = Client?.Name,
                Dan = Dan,
                UnitNum = UnitNum,
                ClientBreakdown = ClientBreakdown,
                Vin = Vin,
                DeliveryType = DeliveryType,
                BuiltOn = BuiltOn,
                MsoMailedOn = MsoMailedOn,
                MsoReceivedOn = MsoReceivedOn,
                DeliveredToDealerOn = DeliveredToDealerOn,
                DeliveredToClientOn = DeliveredToClientOn,
                HoldReason1 = HoldReason1,
                HoldReason2 = HoldReason2,
                HoldReason3 = HoldReason3,
                HoldReason4 = HoldReason4,
                HoldReason5 = HoldReason5,
                DriverFirstName = DriverFirstName,
                DriverLastName = DriverLastName,
                //RequestStates = Requests?.Select(r => r.RequestState) != null && Requests?.Select(r => r.RequestState).Count() > 1 
                //                    ? string.Join(", ", Requests?.Select(r => r.RequestState)) 
                //                    : Requests?.Select(r => r.RequestState).First(),
                //RequestDates = Requests?.Select(r => r.RequestReceivedAt).ToList(),
            };
        }

        public VehicleOrderDTO ToDTO()
        {
            var dto = new VehicleOrderDTO()
            {
                SpinAssetId = SpinAssetId,
                ClientNum = ClientNum,
                ClientName = Client?.Name,
                Dan = Dan,
                UnitNum = UnitNum,
                ClientBreakdown = ClientBreakdown,
                Vin = Vin,
                VehicleMake = VehicleMake,
                VehicleModel = VehicleModel,
                VehicleModelYear = VehicleModelYear,
                VehicleSeries = VehicleSeries,
                DeliveryType = DeliveryType,
                FactoryOrderNumber = FactoryOrderNumber,
                BuiltOn = BuiltOn,
                MsoMailedOn = MsoMailedOn,
                MsoReceivedOn = MsoReceivedOn,
                DeliveredToDealerOn = DeliveredToDealerOn,
                DeliveredToClientOn = DeliveredToClientOn,
                AddedOn = AddedOn,
                HoldReason1 = HoldReason1,
                HoldReason2 = HoldReason2,
                HoldReason3 = HoldReason3,
                HoldReason4 = HoldReason4,
                HoldReason5 = HoldReason5,
                DriverFirstName = DriverFirstName,
                DriverLastName = DriverLastName,
                DriverAddressLine1 = DriverAddressLine1,
                DriverAddressLine2 = DriverAddressLine2,
                DriverCity = DriverCity,
                DriverCounty = DriverCounty,
                DriverStateProv = DriverStateProv,
                DriverPhone = DriverPhone,
                DriverEmail = DriverEmail,
            };
            if (Requests != null && Requests.Any())
            {
                dto.Requests = Requests.Select(r => r.ToDTO()).ToList();
            }
            return dto;
        }

    }
}
