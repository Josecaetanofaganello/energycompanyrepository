using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnergyCompanyConsole.Tests
{
    [TestClass]
    public class ManageEndpointCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenEndpointInsertedIsInvalid()
        {

            ManageEndpointCommand cmd = new ManageEndpointCommand();
            var command = new EndpointCommandHandler(cmd, _cache, CommandType);
            var result = command.Handle(cmd);

        }
    }
}
