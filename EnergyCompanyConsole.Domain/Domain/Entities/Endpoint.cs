using EnergyCompanyConsoleApplication.Domain.Enums;

namespace EnergyCompanyConsoleApplication.Domain.Entities
{
    public class Endpoint
    {
        public Endpoint(string _serialNumber, EMeterModel _meterModelId, int _meterNumber, string _firmwareVersion, ESwitchState _switchState)
        {
            SerialNumber = _serialNumber;
            MeterModelId = _meterModelId;
            MeterNumber = _meterNumber;
            FirmwareVersion = _firmwareVersion;
            SwitchState = _switchState;
        }
        public string SerialNumber { get; private set; }
        public EMeterModel MeterModelId { get; private set; }
        public int MeterNumber { get; private set; }
        public string FirmwareVersion { get; private set; }
        public ESwitchState SwitchState { get; private set; }

        public void ChangeState(ESwitchState state)
        {
            SwitchState = state;
        }
    }
}
