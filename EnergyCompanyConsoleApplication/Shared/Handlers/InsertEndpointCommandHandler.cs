using EnergyCompanyConsoleApplication.Domain.Commands;
using EnergyCompanyConsoleApplication.Domain.Entities;
using EnergyCompanyConsoleApplication.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyCompanyConsoleApplication.Shared.Handlers
{
    public class InsertEndpointCommandHandler : ICommandHandler<InsertEndpointCommand>
    {
        private readonly InsertEndpointCommand _endpoint;
        private readonly IEndpointCacheRepository _cache;
        

        public InsertEndpointCommandHandler(InsertEndpointCommand endPoint, IEndpointCacheRepository cache)
        {
            _endpoint = endPoint;
            _cache = cache;
        }
        public ICommandResult Handle(InsertEndpointCommand command)
        {

            _cache.insert(new Endpoint { FirmwareVersion = _endpoint.FirmwareVersion, MeterModelId = _endpoint.MeterModelId, MeterNumber = _endpoint.MeterNumber, SerialNumber = _endpoint.SerialNumber, SwitchState = _endpoint.SwitchState });
            return new CommandResult(true, $" {_endpoint.SerialNumber} Successfully inserted", new  { persistence = "ok"});
        }
    }
}
