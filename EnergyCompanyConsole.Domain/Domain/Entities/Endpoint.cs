using EnergyCompanyConsoleApplication.Domain.Enums;

namespace EnergyCompanyConsoleApplication.Domain.Entities
{
    public class Endpoint
    {
        public string SerialNumber { get; set; }
        public EMeterModel MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public ESwitchState SwitchState { get; set; }
    }
}
