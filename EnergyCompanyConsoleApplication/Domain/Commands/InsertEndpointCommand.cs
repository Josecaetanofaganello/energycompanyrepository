using EnergyCompanyConsoleApplication.Domain.Enums;

namespace EnergyCompanyConsoleApplication.Domain.Commands
{
    public class InsertEndpointCommand : ICommand
    {
        public InsertEndpointCommand(string serialNumber, EMeterModel meterModelid, int meterNumber, string firmwareVersion, ESwitchState switchState)
        {
            SerialNumber = serialNumber;
            MeterModelId = meterModelid;
            MeterNumber = meterNumber;
            FirmwareVersion = firmwareVersion;
            SwitchState = switchState;
        }
        public string SerialNumber { get; set; }
        public EMeterModel MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public ESwitchState SwitchState { get; set; }

        public bool Valid()
        {
            //check validations
            return true;
        }
    }
}
