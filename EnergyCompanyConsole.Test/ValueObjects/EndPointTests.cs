using EnergyCompanyConsoleApplication.Domain.Commands;
using EnergyCompanyConsoleApplication.Domain.Enums;
using EnergyCompanyConsoleApplication.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnergyCompanyConsole.Test
{
    [TestClass]
    public class EndPointTests
    {
        [TestMethod]
        public void ShouldValidateWhenMeterModelIdIsInvalid()
        {
            IEndpointCacheRepository _cache = new FakeEndpointCacheRepository();
            ManageEndpointCommand cmd = new ManageEndpointCommand();
            cmd.FirmwareVersion = "1.0.0";
            cmd.MeterNumber = 1;
            cmd.MeterModelId = (EMeterModel)88;
            cmd.SerialNumber = "123321";
            cmd.SwitchState = (ESwitchState)2;
            Assert.IsFalse(cmd.Valid());
        }

        [TestMethod]
        public void ShouldValidateWhenMeterModelIdIsInValid()
        {
            ManageEndpointCommand cmd = new ManageEndpointCommand();
            cmd.FirmwareVersion = "1.0.0";
            cmd.MeterNumber = 1;
            cmd.MeterModelId = (EMeterModel)16;
            cmd.SerialNumber = "123321";
            cmd.SwitchState = (ESwitchState)2;
            Assert.IsTrue(cmd.Valid());
        }


        [TestMethod]
        public void ShouldValidateWhenSwitchStateIsInValid()
        {
            ManageEndpointCommand cmd = new ManageEndpointCommand();
            cmd.FirmwareVersion = "1.0.0";
            cmd.MeterNumber = 1;
            cmd.MeterModelId = (EMeterModel)16;
            cmd.SerialNumber = "123321";
            cmd.SwitchState = (ESwitchState)6;
            Assert.IsFalse(cmd.Valid());
        }

        [TestMethod]
        public void ShouldValidateWhenSwitchStateIsValid()
        {
            ManageEndpointCommand cmd = new ManageEndpointCommand();
            cmd.FirmwareVersion = "1.0.0";
            cmd.MeterNumber = 1;
            cmd.MeterModelId = (EMeterModel)16;
            cmd.SerialNumber = "123321";
            cmd.SwitchState = (ESwitchState)2;
            Assert.IsTrue(cmd.Valid());
        }
    }
}
