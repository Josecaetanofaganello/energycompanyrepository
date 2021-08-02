using EnergyCompanyConsoleApplication.Domain.Entities;
using EnergyCompanyConsoleApplication.Domain.Enums;
using EnergyCompanyConsoleApplication.Domain.Repositories;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EnergyCompanyConsole.Test
{
    public class FakeEndpointCacheRepository : IEndpointCacheRepository
    {
        private static readonly ConcurrentDictionary<string, Endpoint> _fakeEndpoints;

        static FakeEndpointCacheRepository()
        {
            _fakeEndpoints = new ConcurrentDictionary<string, Endpoint>();

            Endpoint end0 = new Endpoint { FirmwareVersion = "1.0.0", MeterModelId = (EMeterModel)16, MeterNumber = 1, SerialNumber = "00000000001", SwitchState = (ESwitchState)1 };
            Endpoint end1 = new Endpoint { FirmwareVersion = "1.0.0", MeterModelId = (EMeterModel)17, MeterNumber = 2, SerialNumber = "00000000002", SwitchState = (ESwitchState)2 };
            Endpoint end2 = new Endpoint { FirmwareVersion = "1.0.2", MeterModelId = (EMeterModel)18, MeterNumber = 3, SerialNumber = "00000000003", SwitchState = (ESwitchState)0 };
            Endpoint end3 = new Endpoint { FirmwareVersion = "1.0.3", MeterModelId = (EMeterModel)19, MeterNumber = 4, SerialNumber = "00000000004", SwitchState = (ESwitchState)2 };
            Endpoint end4 = new Endpoint { FirmwareVersion = "1.0.1", MeterModelId = (EMeterModel)17, MeterNumber = 5, SerialNumber = "00000000005", SwitchState = (ESwitchState)2 };
            _fakeEndpoints.TryAdd(end0.SerialNumber,end0);
            _fakeEndpoints.TryAdd(end1.SerialNumber, end1);
            _fakeEndpoints.TryAdd(end2.SerialNumber,end2);
            _fakeEndpoints.TryAdd(end3.SerialNumber,end3);
            _fakeEndpoints.TryAdd(end4.SerialNumber,end4);
        }

        public bool insert(Endpoint endpoint)
        {
            return _fakeEndpoints.TryAdd(endpoint.SerialNumber, endpoint);
        }
        public bool delete(Endpoint endpoint)
        {
            return _fakeEndpoints.TryRemove(endpoint.SerialNumber, out _);
        }

        public bool edit(Endpoint endpoint)
        {
            //find endpoint
            bool findResult = _fakeEndpoints.TryGetValue(endpoint.SerialNumber, out var _endpoint);
            //if exists , try update
            return findResult && _fakeEndpoints.TryUpdate(endpoint.SerialNumber, endpoint, _endpoint);
        }

        public Endpoint Find(string SerialNumber)
        {
            _fakeEndpoints.TryGetValue(SerialNumber, out var endpoint);
            return endpoint;
        }

        public IEnumerable<Endpoint> ListAll()
        {
            return _fakeEndpoints.Values;
        }
    }
}
