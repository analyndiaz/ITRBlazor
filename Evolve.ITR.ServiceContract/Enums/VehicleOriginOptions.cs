using System.ComponentModel.DataAnnotations;

namespace Evolve.ITR.ServiceContract.Enums
{
    public enum VehicleOriginOptions
    {
        [Display(Name = "All Vehicle Origins*")]
        All,
        [Display(Name = "Factory Orders")]
        Factory,
        [Display(Name = "Dealer Stock Orders")]
        Stock,
        [Display(Name = "Unknown Source")]
        Unknown
    }
}
