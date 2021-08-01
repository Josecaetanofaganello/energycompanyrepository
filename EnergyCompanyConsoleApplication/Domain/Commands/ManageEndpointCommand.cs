using EnergyCompanyConsoleApplication.Domain.Enums;
using System;

namespace EnergyCompanyConsoleApplication.Domain.Commands
{
    public class ManageEndpointCommand : ICommand
    {
        public string SerialNumber { get; set; }
        public EMeterModel MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public ESwitchState SwitchState { get; set; }

        public bool Valid()
        {
            //check validations
            if (string.IsNullOrEmpty(SerialNumber))
            {
                return false;
            }
            if (!Enum.IsDefined(typeof(EMeterModel), MeterModelId)){
                return false;
            }
            if (!Enum.IsDefined(typeof(ESwitchState), SwitchState))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
