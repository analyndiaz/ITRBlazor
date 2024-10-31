using System.ComponentModel;

namespace Evolve.ITR.ServiceContract.Enums
{
    public enum VehicleStageOptions
    {
        [Description("Ordered")]
        Ordered,
        [Description("Vehicle Built")]
        Built,
        [Description("Dealer Delivered")]
        DealerDelivered,
        [Description("Client Delivered")]
        ClientDelivered
    }
}
