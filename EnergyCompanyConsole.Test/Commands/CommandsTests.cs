using EnergyCompanyConsoleApplication.Domain.Commands;
using EnergyCompanyConsoleApplication.Domain.Enums;
using EnergyCompanyConsoleApplication.Domain.Repositories;
using EnergyCompanyConsoleApplication.Shared.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnergyCompanyConsole.Test
{
    [TestClass]
    public class CommandsTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandisInvalid()
        {
            IEndpointCacheRepository _cache = new FakeEndpointCacheRepository();
            ManageEndpointCommand cmd = new ManageEndpointCommand();
            cmd.FirmwareVersion = "1.0.0";
            cmd.MeterNumber = 1;
            cmd.MeterModelId = (EMeterModel)88;
            cmd.SerialNumber = "123321";
            cmd.SwitchState = (ESwitchState)2;
            var command = new EndpointCommandHandler(cmd, _cache, (ECommandType)99);
            var result = command.Handle(cmd);
            Assert.IsFalse(cmd.Valid());
            Assert.IsFalse(result.Success);
        }
    }
}
